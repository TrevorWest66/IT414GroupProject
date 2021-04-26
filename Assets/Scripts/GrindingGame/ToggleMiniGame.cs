// Trevor West
// 3/28/2021
// Ends the mini gamne

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ToggleMiniGame : MonoBehaviour
{
    private List<string> Ingrediants = CurrentGameObjects.Instance.Ingredients;
    // this just switches the scene back to the main one, when more mini games are addded will intstead move scene forward
    public void CloseMiniGame()
    {
        // creates a potion and adds it to the players inventory
        PotionCrafter potionMaker = new PotionCrafter();
        Potion madePotion = potionMaker.DeterminePotion(Ingrediants);
        CurrentGameObjects.Instance.AddPotion(madePotion);
        DictionaryItem potionForDict = new Adapter(madePotion.keyName, 1);
        potionForDict.AddToDictionary();
        CurrentGameObjects.Instance.Ingredients.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OpenMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentGameObjects.Instance.GetObjectsPopulated().Clear();
    }
}
