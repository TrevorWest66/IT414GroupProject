﻿// Trevor West
// 03/28/2021
// Main program for the Grinding Mini game

using UnityEngine;
using TMPro;

public class GrindingMain : MonoBehaviour
{
    private Vector3 ButtonPosition;
    private PromptLengthCalc PromptLengthCalculator;
    private PositionGenerator PositionFinder;
    private IKeyPrompt KeyPromptObject;
    private IKeyPrompt Decorator;
    private KeyPicker KeyPromptPicker;
    private CorrectKeyPress CorrectKey;
    public GameObject PlayerScoreDisplay;
    public GameObject StartPanel;
    public GameObject EndPanel;
    public GameObject FinalPlayerScore;
    public GameObject StrikeOne;
    public GameObject StrikeTwo;
    public GameObject StrikeThree;

    bool startGame = false;
    int strikes = 0;
    private readonly float scale = 1f;
    private readonly int xClamp, yClamp = 5;
    private float promptLength = 5f;
    float miniGameTimer = 0f;
    float promptTimer = 0f;

    public void EndGame()
    {
        startGame = false;
        // Destroys the prompt
        GameObject.Destroy(GameObject.Find("KeyPromptImage"));
        GameObject.Destroy(GameObject.Find("IndicatedKey"));
        // Switches to the end screen and adds final score to final score display
        PlayerScoreDisplay.SetActive(false);
        EndPanel.SetActive(true);
        FinalPlayerScore.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");

    }

    public void PlayGame()
    {
        // Starts the game and switches off the main menu
        startGame = true;
        PlayerPrefs.SetInt("GrindingMiniGameScore", 0);
        PlayerScoreDisplay.SetActive(true);
        StartPanel.SetActive(false);
        strikes = 0;
    }

    void Start()
    {
        // Intializes basic variables
        PromptLengthCalculator = new PromptLengthCalc();
        PositionFinder = new PositionGenerator();
        KeyPromptPicker = new KeyPicker();
        CorrectKey = new CorrectKeyPress();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the game has been started
        if (startGame)
        {
            // Increases the timer for the game
            miniGameTimer += Time.deltaTime;
            // If there are no prompt objects creates them
            if (GameObject.Find("KeyPromptImage") == null)
            {
                // Determines the prompt length
                promptLength = PromptLengthCalculator.DeterminePropmptLength(miniGameTimer);
                // Determines the prompts location
                ButtonPosition = PositionFinder.GeneratePosition(xClamp, yClamp);
                // Creates the prompt
                KeyPromptObject = new KeyPrompt(ButtonPosition, scale);
                // Make the object editble by the decorator
                IKeyPrompt keyPromptDecorator = new KeyPromptDecorator(KeyPromptObject);
                // Picks a decorator to add an image for a key
                Decorator = KeyPromptPicker.PickKeyPrompt(keyPromptDecorator);
                // Decorator adds the key image to the prompt
                Decorator.GetObjectForSprite();
                // Sets the timer for the pompt to 0
                promptTimer = 0f;
            }

            // Calls the method to see if the correct key is pressed, increments the strikes if not
            strikes += CorrectKey.Determine(Decorator, PlayerScoreDisplay);

            // Increases the timer for the prompt
            promptTimer += Time.deltaTime;

            // If the prompt timer exceeds the allowed time destroys the prompt and adds a strike
            if (promptTimer >= promptLength)
            {
                GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                GameObject.Destroy(GameObject.Find("IndicatedKey"));
                strikes += 1;
            }

            if (strikes == 1)
            {
                StrikeOne.SetActive(true);
            }
            else if (strikes == 2)
            {
                StrikeOne.SetActive(true);
                StrikeTwo.SetActive(true);
            }
            else if (strikes == 3)
            {
                StrikeOne.SetActive(true);
                StrikeTwo.SetActive(true);
                StrikeThree.SetActive(true);
            }

            // If the user gets 3 strikes ends the game
            if (strikes >= 3)
            {
                EndGame();
            }
        }
    }
}
