using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    [SerializeField] public bool isLeftSide;
    [SerializeField] Vector3 LeftSideStartPosi;
    [SerializeField] Vector3 RightSideStartPosi;
    [SerializeField] public bool isSwingBowling;
    [SerializeField] float spinAngle;
    [SerializeField] float swingAngle;
    [SerializeField] float bounceFactor = 0.7f;

    public float bowlDuration = 1f; // Time to reach the pitch

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

    public void Reset()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        SwitchBowlingSide();
    }

    public void Bowl(Vector3 hitGroundPosition)
    {
        // Setup the initial bowling path
        float effectAngle = isSwingBowling ? swingAngle : 0f;
        MoveToPitch(transform.position, hitGroundPosition, effectAngle);
    }

    // Function 1: Handle all movement BEFORE hitting the pitch
    void MoveToPitch(Vector3 startPos, Vector3 pitchPos, float lateralAngle)
    {
        Vector3 start = startPos;
        Vector3 end = pitchPos;

        // Direction from start to end
        Vector3 flatDir = (end - start);
        flatDir.y = 0;
        Vector3 directionVector = Vector3.Cross(Vector3.up, flatDir).normalized;

        // Create a middle control point with appropriate effect
        Vector3 mid = Vector3.Lerp(start, end, 0.5f);
        mid += directionVector * lateralAngle; // For swing: use angle, for spin: angle = 0
        mid.y += 2f; // Height adjustment

        StartCoroutine(MoveBeforePitch(start, mid, end, bowlDuration));
    }

    // Function 2: Handle all movement AFTER hitting the pitch
    void MoveAfterPitch(Vector3 pitchPos, Vector3 direction, float effectAngle)
    {
        // For swing: effectAngle = 0, for spin: effectAngle = spinAngle
        Vector3 directionVector = Vector3.Cross(Vector3.up, direction).normalized;

        // Apply velocity with appropriate direction and effect
        Vector3 velocity = direction.normalized * 10f; // Base velocity
        velocity += directionVector * effectAngle * 0.5f; // Add lateral effect
        velocity.y = Mathf.Abs(velocity.y) * bounceFactor; // Bounce effect

        // Enable physics and apply the velocity
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = velocity;
    }

    IEnumerator MoveBeforePitch(Vector3 start, Vector3 control, Vector3 end, float duration)
    {
        // Make sure the ball is kinematic during the controlled movement
        rb.isKinematic = true;
        rb.useGravity = false;

        float timer = 0f;
        Vector3 previousPos = transform.position;
        float maxProgress = 0.95f; // Stop slightly before the ground

        while (timer < duration * maxProgress)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / (duration * maxProgress));

            // Quadratic Bezier formula
            Vector3 pos =
                Mathf.Pow(1 - t, 2) * start +
                2 * (1 - t) * t * control +
                Mathf.Pow(t, 2) * end;

            previousPos = transform.position;
            transform.position = pos;

            yield return null;
        }

        // Calculate velocity at the moment of impact
        Vector3 impactDirection = (transform.position - previousPos).normalized;

        // Now handle post-pitch movement with appropriate effect
        // For swing bowling: no spin (0)
        // For spin bowling: apply spin angle
        float afterPitchEffect = isSwingBowling ? 0f : spinAngle;
        MoveAfterPitch(transform.position, impactDirection, afterPitchEffect);
    }
}
