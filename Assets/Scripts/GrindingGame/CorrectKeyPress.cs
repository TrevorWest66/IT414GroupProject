using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

class CorrectKeyPress
{
    public int Determine(IKeyPrompt prompt, GameObject playerScore)
    {
        string correctKey = prompt.GetKeyValue();
        int strikes = 0;
        if (Input.anyKeyDown)
        {
            if (correctKey.Equals("W"))
            {
                if (Input.GetKeyDown(KeyCode.W))
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
            if (correctKey.Equals("A"))
            {
                if (Input.GetKeyDown(KeyCode.A))
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
                if (Input.GetKeyDown(KeyCode.S))
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
                if (Input.GetKeyDown(KeyCode.D))
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

        // Delete later, for testing
        if (strikes == 1)
        {
            Debug.Log("Strike!");
        }

        return strikes;
    }
}
