using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        /** Deactivates the menu, this is preserved by the KeyboardControls 
         * class in order to save player preferences
         */
        GameObject.FindGameObjectWithTag("MainMenuScreen").SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
