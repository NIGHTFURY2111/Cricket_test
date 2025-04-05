using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    [SerializeField] public bool isLeftSide;
    [SerializeField] Vector3 LeftSideStartPosi;
    [SerializeField] Vector3 RightSideStartPosi;
    [SerializeField]  public bool isSwingBowling;
    [SerializeField] float spinAngle;
    [SerializeField] float swingAngle;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SwitchBowlingSide();
        rb.useGravity = false;
    }
    public void SwitchBowlingSide()
    {
        transform.position = isLeftSide ? LeftSideStartPosi : RightSideStartPosi;
    }

    public void Bowl(Vector3 hitGroundPosition)
    {

        if (isSwingBowling)
        {
            SwingBowl(hitGroundPosition, swingAngle);
        }
        else
        {
            SpinBowl(hitGroundPosition, spinAngle);
        }
    }


    public float bowlDuration = 1f; // Time to reach the pitch

    void SwingBowl(Vector3 hitGroundPosition, float swingAngle)
    {
        Vector3 start = transform.position;
        Vector3 end = hitGroundPosition;

        // Direction from start to end
        Vector3 flatDir = (end - start);
        flatDir.y = 0;
        Vector3 swingDir = Vector3.Cross(Vector3.up, flatDir).normalized;

        // Create a middle control point offset for swing
        Vector3 mid = Vector3.Lerp(start, end, 0.5f);
        mid += swingDir * swingAngle;

        StartCoroutine(SwingBezier(start, mid, end, bowlDuration));
    }

    IEnumerator SwingBezier(Vector3 start, Vector3 control, Vector3 end, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);

            // Quadratic Bezier formula
            Vector3 pos =
                Mathf.Pow(1 - t, 2) * start +
                2 * (1 - t) * t * control +
                Mathf.Pow(t, 2) * end;

            transform.position = pos;
            yield return null;
        }
    }

    void SpinBowl(Vector3 hitGroundPosition, float spinAngle)
    {
        // Step 1: Ball travels straight to pitch
        StartCoroutine(MoveStraightThenSpin(hitGroundPosition, spinAngle));
    }

    IEnumerator MoveInArc(Vector3 start, Vector3 end, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;

            // Basic arc height calculated from start and end positions
            float arcPeak = Mathf.Lerp(start.y, end.y, 0.5f) + 1f; // dynamic height, 1 unit arc

            // Lerp flat position
            Vector3 flatPos = Vector3.Lerp(start, end, t);

            // Add arc using parabola shape
            float arc = 4 * (t - t * t) * (arcPeak - Mathf.Lerp(start.y, end.y, t)); // smooth parabolic arc
            flatPos.y += arc;

            transform.position = flatPos;

            yield return null;
        }
    }

    IEnumerator MoveStraightThenSpin(Vector3 pitchPoint, float spinAngle)
    {
        float halfDuration = bowlDuration * 0.5f;

        // First half: straight to pitch
        Vector3 start = transform.position;
        float timer = 0f;
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float t = timer / halfDuration;
            Vector3 pos = Vector3.Lerp(start, pitchPoint, t);
            transform.position = pos;
            yield return null;
        }

        // Second half: spin deviation after bounce
        Vector3 spinDir = Vector3.Cross(Vector3.up, (pitchPoint - start)).normalized;
        Vector3 spinTarget = pitchPoint + spinDir * spinAngle;

        timer = 0f;
        while (timer < halfDuration)
        {
            timer += Time.deltaTime;
            float t = timer / halfDuration;
            Vector3 pos = Vector3.Lerp(pitchPoint, spinTarget, t);
            transform.position = pos;
            yield return null;
        }
    }



}
