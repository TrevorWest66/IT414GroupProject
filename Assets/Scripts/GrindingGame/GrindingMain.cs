// Trevor West
// 3/28/2021
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

    public void EndGmae()
    {
        startGame = false;
        // destroys the prompt
        GameObject.Destroy(GameObject.Find("KeyPromptImage"));
        GameObject.Destroy(GameObject.Find("IndicatedKey"));
        // switches to the end screen and adds final score to final score display
        PlayerScoreDisplay.SetActive(false);
        EndPanel.SetActive(true);
        FinalPlayerScore.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");

    }

    public void PlayGame()
    {
        // starts the game and switches off the main menu
        startGame = true;
        PlayerPrefs.SetInt("GrindingMiniGameScore", 0);
        PlayerScoreDisplay.SetActive(true);
        StartPanel.SetActive(false);
        strikes = 0;
    }

    void Start()
    {
        // intializes basic vaiables
        PromptLengthCalculator = new PromptLengthCalc();
        PositionFinder = new PositionGenerator();
        KeyPromptPicker = new KeyPicker();
        CorrectKey = new CorrectKeyPress();
    }

    // Update is called once per frame
    void Update()
    {
        // chekcs if the game has been started
        if (startGame)
        {
            // increases the timer for the game
            miniGameTimer += Time.deltaTime;
            // if there are no prompt objects creates them
            if (GameObject.Find("KeyPromptImage") == null)
            {
                // determines the prompt length
                promptLength = PromptLengthCalculator.DeterminePropmptLength(miniGameTimer);
                // Determines the prompts location
                ButtonPosition = PositionFinder.GeneratePosition(xClamp, yClamp);
                // Creates the prompt
                KeyPromptObject = new KeyPrompt(ButtonPosition, scale);
                // make the object editble by the decorator
                IKeyPrompt keyPromptDecorator = new KeyPromptDecorator(KeyPromptObject);
                // picks a decorator to add an image for a key
                Decorator = KeyPromptPicker.PickKeyPrompt(keyPromptDecorator);
                // decorator adds the key image to the prompt
                Decorator.GetObjectForSprite();
                // sets the timer for the pompt to 0
                promptTimer = 0f;
            }

            // Calls the method to see if the correct key is pressed, increments the strikes if not
            strikes += CorrectKey.Determine(Decorator, PlayerScoreDisplay);

            // increases the timer for the prompt
            promptTimer += Time.deltaTime;

            // if the prompt timer exceeds the allowed time destroys the prompt and adds a strike
            if (promptTimer >= promptLength)
            {
                GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                GameObject.Destroy(GameObject.Find("IndicatedKey"));
                strikes += 1;
            }

            Debug.Log(strikes);
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

            // if the user gets 3 strikes ends the game
            if (strikes >= 3)
            {
                EndGmae();
            }
        }
    }
}
