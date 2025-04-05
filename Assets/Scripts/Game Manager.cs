using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    bool isBowling;

    PlayerControls playerControls;
    InputAction moveAction;

    [SerializeField] GameObject puckGameObject;
    [SerializeField] GameObject BallGameObject;
    MovePuck puckScript;

    #region input system setup
    private void Awake()
    {
        playerControls = new PlayerControls();
        puckScript = puckGameObject.GetComponent<MovePuck>();
        moveAction = playerControls.HitPoint.move;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    #endregion

    public Vector2 MoveDir => moveAction.ReadValue<Vector2>();

    void Update()
    {
        if (isBowling)
        {
            puckScript.movePuck(MoveDir);
        }
    }
}
