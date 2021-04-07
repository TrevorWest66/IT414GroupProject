// Trevor West
// 3/28/2021
// Ends the mini gamne

using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleMiniGame : MonoBehaviour
{
    // this just switches the scene back to the main one, when more mini games are addded will intstead move scene forward
    public void CloseMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OpenMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentGameObjects.Instance.getObjectsPopulated().Clear();
    }
}
