using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    bool isBowling;
    bool canBowl = true; // New flag to track if bowling is allowed

    PlayerControls playerControls;
    InputAction moveAction;
    InputAction bowlAction;
    InputAction resetAction;

    [SerializeField] GameObject puckGameObject;
    [SerializeField] GameObject BallGameObject;
    [SerializeField] SliderFunctions sliderFunctions;
    [SerializeField] private string accuracyText; // Display for debugging
    MovePuck puckScript;
    BallScript ballScript;

    #region input system setup
    private void Awake()
    {
        playerControls = new PlayerControls();
        puckScript = puckGameObject.GetComponent<MovePuck>();
        ballScript = BallGameObject.GetComponent<BallScript>();
        moveAction = playerControls.HitPoint.move;
        bowlAction = playerControls.HitPoint.Bowl;
        resetAction = playerControls.HitPoint.reset;
        isBowling = false;
        canBowl = true; // Can bowl at the start of the game
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

    // Calculate accuracy based on zones
    private float CalculateAccuracyFromZone(float sliderValue)
    {
        // Convert slider value from 0-1 to 0-100 for easier zone calculation
        float value = sliderValue * 100f;

        // Determine the accuracy zone
        if (value <= 1 || value >= 99)
        {
            accuracyText = "Miss!"; // For debugging
            return 0f; // 0% accuracy
        }
        else if ((value > 1 && value <= 10) || (value >= 90 && value < 99))
        {
            accuracyText = "Poor"; // For debugging
            return 0.2f; // 20% accuracy
        }
        else if ((value > 10 && value <= 25) || (value >= 75 && value < 90))
        {
            accuracyText = "Fair"; // For debugging
            return 0.4f; // 40% accuracy
        }
        else if ((value > 25 && value <= 40) || (value >= 60 && value < 75))
        {
            accuracyText = "Good"; // For debugging
            return 0.7f; // 70% accuracy
        }
        else // value > 40 && value < 60 (center zone)
        {
            accuracyText = "Perfect!"; // For debugging
            return 1f; // 100% accuracy
        }
    }

    void Update()
    {
        if (!isBowling)
        {
            puckScript.movePuck(MoveDir);
        }

        if (bowlAction.WasPressedThisFrame() && canBowl)
        {
            InitiateBowling();
        }

        if (resetAction.WasPressedThisFrame())
        {
            ResetGame();
        }
    }

    // Public method for initiating the bowling action - can be called by buttons
    public void InitiateBowling()
    {
        if (!canBowl) return; // Guard clause to prevent invalid bowling

        if (!isBowling)
        {
            // Start the slider when the player decides to bowl
            sliderFunctions.StartSliderFunction();
            isBowling = true;
        }
        else
        {
            // Get the slider value and calculate accuracy using the zone system
            float sliderValue = sliderFunctions.StopGetSliderValue();
            float accuracy = CalculateAccuracyFromZone(sliderValue);

            // Debug.Log for testing accuracy
            Debug.Log($"Slider: {sliderValue:F2}, Accuracy: {accuracy:F2}, Zone: {accuracyText}");

            ballScript.Bowl(puckGameObject.transform.position, accuracy);
            isBowling = false;
            canBowl = false; // Prevent bowling until reset
        }
    }

    // Public method for resetting the game - can be called by buttons
    public void ResetGame()
    {
        isBowling = false;
        canBowl = true; // Allow bowling after reset
        puckScript.Reset();
        ballScript.Reset();
    }

    public void IsBowlingFromLeft(bool isLeft)
    {
        ballScript.isLeftSide = isLeft;
        ballScript.SwitchBowlingSide();
    }

    public void IsSwingBowling(bool isSwingBowling)
    {
        ballScript.isSwingBowling = isSwingBowling;
    }
}
