// Written by Trevor West
// 03/03/2021
// This is the logic behind the main menu scene where the user can select play, options, or quit

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Play button is pressed so the main scene is loaded and the main menu scene is disabled
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        /** Deactivates the menu, this is preserved by the KeyboardControls 
         * class in order to save player preferences
         */
        GameObject.FindGameObjectWithTag("MainMenuScreen").SetActive(false);
    }

    // Quit button is pressed
    public void QuitGame()
    {
        Application.Quit();
    }
}
