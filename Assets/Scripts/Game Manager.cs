using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject puckGameObject;
    [SerializeField] private GameObject ballGameObject;
    [SerializeField] private SliderFunctions sliderFunctions;

    // Accuracy zones configuration - could be moved to ScriptableObject
    [SerializeField] private float[] accuracyZoneBounds = { 1f, 10f, 25f, 40f, 60f, 75f, 90f, 99f };
    [SerializeField] private float[] accuracyZoneValues = { 0f, 0.2f, 0.4f, 0.7f, 1f, 0.7f, 0.4f, 0.2f, 0f };
    [SerializeField] private string[] accuracyZoneTexts = { "Miss!", "Poor", "Fair", "Good", "Perfect!", "Good", "Fair", "Poor", "Miss!" };

    private MovePuck _puckScript;
    private BallScript _ballScript;
    private PlayerControls _playerControls;
    private InputAction _moveAction;
    private InputAction _bowlAction;
    private InputAction _resetAction;

    private bool _isBowling;
    private bool _canBowl = true;
    private string _accuracyText;

    // Public event for UI to subscribe to
    public event Action<string, float> OnAccuracyCalculated;

    #region Unity Lifecycle

    private void Awake()
    {
        InitializeComponents();
        SetupInputActions();
    }

    private void OnEnable()
    {
        EnableInputActions();
    }

    private void OnDisable()
    {
        DisableInputActions();
    }

    private void Update()
    {
        HandleInput();
    }

    #endregion

    #region Initialization

    private void InitializeComponents()
    {
        _puckScript = puckGameObject?.GetComponent<MovePuck>();
        _ballScript = ballGameObject?.GetComponent<BallScript>();
        _playerControls = new PlayerControls();
    }

    private void SetupInputActions()
    {
        if (_playerControls == null) return;

        _moveAction = _playerControls.HitPoint.move;
        _bowlAction = _playerControls.HitPoint.Bowl;
        _resetAction = _playerControls.HitPoint.reset;
    }

    private void EnableInputActions()
    {
        _moveAction?.Enable();
        _bowlAction?.Enable();
        _resetAction?.Enable();
    }

    private void DisableInputActions()
    {
        _moveAction?.Disable();
        _bowlAction?.Disable();
        _resetAction?.Disable();
    }

    #endregion

    #region Input Handling

    private void HandleInput()
    {
        if (!_isBowling && _puckScript != null)
        {
            _puckScript.movePuck(_moveAction.ReadValue<Vector2>());
        }

        if (_bowlAction.WasPressedThisFrame() && _canBowl)
        {
            InitiateBowling();
        }

        if (_resetAction.WasPressedThisFrame())
        {
            ResetGame();
        }
    }

    public Vector2 MoveDir => _moveAction?.ReadValue<Vector2>() ?? Vector2.zero;

    #endregion

    #region Public Methods

    /// <summary>
    /// Initiates the bowling process or completes it if already in progress
    /// </summary>
    public void InitiateBowling()
    {
        if (!_canBowl) return;

        if (!_isBowling)
        {
            StartBowling();
        }
        else
        {
            CompleteBowling();
        }
    }

    /// <summary>
    /// Resets the game state
    /// </summary>
    public void ResetGame()
    {
        _isBowling = false;
        _canBowl = true;

        if (_puckScript != null) _puckScript.Reset();
        if (_ballScript != null) _ballScript.Reset();
    }

    /// <summary>
    /// Sets the bowling side
    /// </summary>
    public void IsBowlingFromLeft(bool isLeft)
    {
        if (_ballScript == null) return;

        _ballScript.isLeftSide = isLeft;
        _ballScript.SwitchBowlingSide();
    }

    /// <summary>
    /// Sets the bowling type
    /// </summary>
    public void IsSwingBowling(bool isSwingBowling)
    {
        if (_ballScript == null) return;

        _ballScript.isSwingBowling = isSwingBowling;
    }

    #endregion

    #region Private Methods

    private void StartBowling()
    {
        if (sliderFunctions == null) return;

        sliderFunctions.StartSliderFunction();
        _isBowling = true;
    }

    private void CompleteBowling()
    {
        if (sliderFunctions == null || _ballScript == null || _puckScript == null) return;

        float sliderValue = sliderFunctions.StopGetSliderValue();
        float accuracy = CalculateAccuracyFromZone(sliderValue);

        // Notify any UI listeners
        OnAccuracyCalculated?.Invoke(_accuracyText, accuracy);

        Debug.Log($"Slider: {sliderValue:F2}, Accuracy: {accuracy:F2}, Zone: {_accuracyText}");

        _ballScript.Bowl(_puckScript.transform.position, accuracy);
        _isBowling = false;
        _canBowl = false;
    }

    private float CalculateAccuracyFromZone(float sliderValue)
    {
        float value = sliderValue * 100f;

        // Find which zone the value falls into
        for (int i = 0; i < accuracyZoneBounds.Length; i++)
        {
            if (value <= accuracyZoneBounds[i])
            {
                _accuracyText = accuracyZoneTexts[i];
                return accuracyZoneValues[i];
            }
        }

        // Default for values > 99
        _accuracyText = accuracyZoneTexts[accuracyZoneTexts.Length - 1];
        return accuracyZoneValues[accuracyZoneValues.Length - 1];
    }

    #endregion
}
