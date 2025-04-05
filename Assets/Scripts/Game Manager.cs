using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    PlayerControls playerControls;
    InputAction moveAction;

    [SerializeField] GameObject puckGameObject;
    [SerializeField] GameObject BallGameObject;

    #region input system setup
    private void Awake()
    {
        playerControls = new PlayerControls();
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
        Debug.Log(MoveDir);
    }
}
