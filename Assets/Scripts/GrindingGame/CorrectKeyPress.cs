// Trevor West
// 3/28/2021
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
                // if the prompt key is W checks if the W key is pressed and if it is updates score on screen and in player prefs
                // then destroys the prompt
                // if the key is wrong it adds a strike
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    //score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                }
            }
            // The rest works the same as the first if statemnet just checks different keys
            if (correctKey.Equals("A"))
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    //score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                }
            }
            if (correctKey.Equals("S"))
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    //score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                }
            }
            if (correctKey.Equals("D"))
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                }
            }
            if (correctKey.Equals("Space"))
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //score increase will go here
                    PlayerPrefs.SetInt("GrindingMiniGameScore", PlayerPrefs.GetInt("GrindingMiniGameScore") + 1);
                    playerScore.GetComponent<TextMeshPro>().SetText(PlayerPrefs.GetInt("GrindingMiniGameScore") + "");
                    GameObject.Destroy(GameObject.Find("KeyPromptImage"));
                    GameObject.Destroy(GameObject.Find("IndicatedKey"));
                }
                else
                {
                    strikes = 1;
                }
            }
        }

        // Currently shows striks in the debugger later will add this to images on the screen and delete this part
        if (strikes == 1)
        {
            Debug.Log("Strike!");
        }

        // returns if the there was a strike
        return strikes;
    }
}
