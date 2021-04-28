// Trevor West
// 03/28/2021
// Ends the mini gamne

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ToggleMiniGame : MonoBehaviour
{
    private List<string> ingredients = PlantPotionObjects.Instance.GetPlantsInPotion();

    // This just switches the scene back to the main scene; when more mini games are addded will intstead move scene forward
    public void CloseMiniGame()
    {
        // Creates a potion and adds it to the players inventory
        PotionCrafter potionMaker = new PotionCrafter();
        Potion madePotion = potionMaker.DeterminePotion(ingredients);
        // Remove the plants from player inventory that were used in the potion
        CurrentGameObjects.Instance.RemoveCollectedPlantsUsedInPotions(ingredients);
        DictionaryItem potionForDict = new Adapter(madePotion.KeyName, 1);
        // Add potion to current game object collected list of objects collected in order for it to appear in the inventory
        potionForDict.AddToDictionary();
        // Remove plants from plant potion objects and current game objects, these plants were used in the potions
        PlantPotionObjects.Instance.RemoveAllPlantsInPotion();
        // they key is created in potionDictAdapter
        madePotion.KeyName = PlayerPrefs.GetString("ThePotionKey");
        CurrentGameObjects.Instance.AddPotion(madePotion);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Switches the scene from the main scene to the next scene, the mini game scene
    public void OpenMiniGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentGameObjects.Instance.GetObjectsPopulated().Clear();
    }
}
