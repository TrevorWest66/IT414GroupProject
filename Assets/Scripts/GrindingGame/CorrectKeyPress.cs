// Trevor West
// 03/28/2021
// Determines if the correct key was pressed

using UnityEngine;
using TMPro;

public class CorrectKeyPress
{
    public int Determine(IKeyPrompt prompt, GameObject playerScore)
    {
        string correctKey = prompt.GetKeyValue();
        int strikes = 0;

        // Checks if a key has been pressed before validating if it was the correct key
        if (Input.anyKeyDown)
        {
            // Checks if the prompt key is W
            if (correctKey.Equals("W"))
            {
                // If the prompt key is W checks if the W key is pressed and if it is updates score on screen and in player prefs
                // then destroys the prompt.
                // If the key is wrong it adds a strike
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    // Score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                    return strikes;
                }
            }
            // The rest works the same as the first if statemnet just checks different keys
            if (correctKey.Equals("A"))
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    // Score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                    return strikes;
                }
            }
            if (correctKey.Equals("S"))
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    // Score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                    return strikes;
                }
            }
            if (correctKey.Equals("D"))
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    // Score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                    return strikes;
                }
            }
            if (correctKey.Equals("Space"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // Score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                    return strikes;
                }
            }
        }

        // Returns if the there was no strike
        return strikes;
    }
}
