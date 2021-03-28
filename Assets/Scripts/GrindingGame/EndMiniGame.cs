// Trevor West
// 3/28/2021

using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMiniGame : MonoBehaviour
{
    // this just switches the scene back to the main one, when more mini games are addded will intstead move scene forward
    public void CloseMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
