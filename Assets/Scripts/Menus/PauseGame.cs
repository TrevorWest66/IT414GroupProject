// Written by Trevor West
// 03/04/2021
// This is the logic behind the pause menu where the user can resume the game, modify game options, or quit the game

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Resume game
    public void Resume()
    {
        // Locks the users cursor when the game resumes
        Cursor.lockState = CursorLockMode.Locked;

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pause game
    public void Pause()
    {
        // Unlocks the users cursor when the game pauses
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Quit game
    public void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
