using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrindingMain : MonoBehaviour
{
    private readonly float Scale = 2f;
    private readonly int XClamp, YClamp = 5;
    private float PromptLength = 5f;
    float MiniGameTimer = 0f;
    float PromptTimer = 0f;
    private Vector3 ButtonPosition;
    PromptLengthCalc PromptLengthCalculator;
    PositionGenerator PositionFinder;
    IKeyPrompt KeyPromptObject;
    IKeyPrompt Decorator;
    KeyPicker KeyPromptPicker;
    CorrectKeyPress CorrectKey;
    public GameObject PlayerScoreDisplay;
    public GameObject StartPanel;
    public GameObject EndPanel;
    public GameObject FinalPlayerScore;
    bool StartGame = false;
    int Strikes = 0;

    public void EndGmae()
    {
        StartGame = false;
        GameObject.Destroy(GameObject.Find("KeyPromptImage"));
        GameObject.Destroy(GameObject.Find("IndicatedKey"));
        PlayerScoreDisplay.SetActive(false);
        EndPanel.SetActive(true);
        FinalPlayerScore.GetComponent<TextMeshProUGUI>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");

    }

    public void PlayGame()
    {
        StartGame = true;
        PlayerScoreDisplay.SetActive(true);
        StartPanel.SetActive(false);
    }

    void Start()
    {
        // Delete later just for testing purposes
        PlayerPrefs.SetInt("GrindingMiniGameScore", 0);

        PromptLengthCalculator = new PromptLengthCalc();
        PositionFinder = new PositionGenerator();
        KeyPromptPicker = new KeyPicker();
        CorrectKey = new CorrectKeyPress();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartGame)
        {
            MiniGameTimer += Time.deltaTime;
            if (GameObject.Find("KeyPromptImage") == null)
            {
                PromptLength = PromptLengthCalculator.DeterminePropmptLength(MiniGameTimer);
                ButtonPosition = PositionFinder.GeneratePosition(XClamp, YClamp);
                KeyPromptObject = new KeyPrompt(ButtonPosition, Scale);
                IKeyPrompt keyPromptDecorator = new KeyPromptDecorator(KeyPromptObject);
                Decorator = KeyPromptPicker.PickKeyPrompt(keyPromptDecorator);
                Decorator.GetObjectForSprite();
                PromptTimer = 0f;
            }

            PromptTimer += Time.deltaTime;

            if (PromptTimer >= PromptLength)
            {
                GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                GameObject.Destroy(GameObject.Find("IndicatedKey"));
                Strikes += 1;
            }

            Strikes += CorrectKey.Determine(Decorator, PlayerScoreDisplay);

            if (Strikes >= 3)
            {
                EndGmae();
            }
        }
    }
}
