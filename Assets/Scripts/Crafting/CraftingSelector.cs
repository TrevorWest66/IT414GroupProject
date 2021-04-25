// Written by Rebecca Henry
// 4/25/21
// This class is responsible for adding the plants the player choosen to the PlantPotion singleton
using UnityEngine;
using UnityEngine.UI;

public class CraftingSelector : MonoBehaviour
{
    public Image img;
    public Button backButton;
    public PlantPotionObjects potionIngredients = PlantPotionObjects.Instance; // Gets the list of the plants for a potion

    public void PlantToCraftPotion()
    {
        string PlantName = img.GetComponent<Image>().sprite.name;
        GameObject PlantObject = GameObject.Find(PlantName); // Finds the plant gameobject

        potionIngredients.addPlantInPotion(PlantObject); // Adds to potion ingredient list
        CurrentGameObjects.Instance.removeObject(PlantObject);  // Removes the plant from the inventory

        img.GetComponent<Image>().color = new Color(1, 0, 0);   // Sets the color of the image to red to distingish what plant is selected

        Debug.Log("Plant added to list " + potionIngredients.plantsInPotionCount());
    }

    // Clears the list of plant objects so it can reset when the player leaves the inventory / crafting menu
    public void ResetPlantsSelected()
    {
        potionIngredients.removeAllPlantsInPotion();
    }
}
