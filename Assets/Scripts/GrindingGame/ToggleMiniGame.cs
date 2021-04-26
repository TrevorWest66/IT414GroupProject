// Trevor West
// 03/28/2021
// Ends the mini gamne

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ToggleMiniGame : MonoBehaviour
{
    private List<string> Ingrediants = CurrentGameObjects.Instance.Ingredients;

    // This just switches the scene back to the main scene; when more mini games are addded will intstead move scene forward
    public void CloseMiniGame()
    {
        // Creates a potion and adds it to the players inventory
        PotionCrafter potionMaker = new PotionCrafter();
        Potion madePotion = potionMaker.DeterminePotion(Ingrediants);
        CurrentGameObjects.Instance.AddPotion(madePotion);
        DictionaryItem potionForDict = new Adapter(madePotion.keyName, 1);
        potionForDict.AddToDictionary();
        CurrentGameObjects.Instance.Ingredients.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Switches the scene from the main scene to the next scene, the mini game scene
    public void OpenMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentGameObjects.Instance.GetObjectsPopulated().Clear();
    }
}
