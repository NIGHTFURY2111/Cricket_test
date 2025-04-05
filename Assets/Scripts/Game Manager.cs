using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    bool isBowling;

    PlayerControls playerControls;
    InputAction moveAction;
    InputAction bowlAction;
    InputAction resetAction;

    [SerializeField] GameObject puckGameObject;
    [SerializeField] GameObject BallGameObject;
    MovePuck puckScript;
    BallScript ballScript;

    #region input system setup
    private void Awake()
    {
        playerControls = new PlayerControls();
        puckScript = puckGameObject.GetComponent<MovePuck>();
        ballScript = BallGameObject.GetComponent<BallScript>();
        moveAction = playerControls.HitPoint.move;
        bowlAction= playerControls.HitPoint.Bowl;
        resetAction= playerControls.HitPoint.reset;
        isBowling = false;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        bowlAction.Enable();
        resetAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        bowlAction.Disable();
        resetAction.Disable();
    }

    #endregion

    public Vector2 MoveDir => moveAction.ReadValue<Vector2>();

    void Update()
    {
        if (!isBowling)
        {
            puckScript.movePuck(MoveDir);
        }

        if (bowlAction.WasPressedThisFrame())
        {
            ballScript.Bowl(puckGameObject.transform.position);
            isBowling = true;
        }

        if (resetAction.WasPressedThisFrame())
        {
            isBowling = false;
            puckScript.Reset();
            ballScript.Reset();
        }
    }

    public void IsBowlingFromLeft (bool isLeft)
    {
        ballScript.isLeftSide = isLeft;
        ballScript.SwitchBowlingSide();
    }
    public void IsSwingBowling (bool isSwingBowling)
    {
        ballScript.isSwingBowling= isSwingBowling;
    }
}
