﻿// Written by Rebecca Henry
// 04/25/21
// This class is responsible for adding the plants the player choosen to the PlantPotion singleton
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSelector : MonoBehaviour
{
    public Image img;
    public Button backButton;
    public PlantPotionObjects potionIngredients = PlantPotionObjects.Instance; // Gets the list of the plants for a potion

    public void PlantToCraftPotion()
    {
        string PlantNameOfImage = img.GetComponent<Image>().sprite.name;
        string aPlant = PlantNameOfImage.Substring(0, PlantNameOfImage.Length - 6);
        GameObject PlantObject = GameObject.Find(aPlant); // Finds the plant gameobject

        potionIngredients.AddPlantInPotion(PlantObject.name); // Adds to potion ingredient list
        CurrentGameObjects.Instance.RemoveObject(PlantObject);  // Removes the plant from the inventory

        ColorizePlantSelection(PlantObject);
    }

    // Clears the list of plant objects so it can reset when the player leaves the inventory / crafting menu
    public void ResetPlantsSelected()
    {
        ClearAllColorPlantSelection();
        potionIngredients.RemoveAllPlantsInPotion();
    }

    public void ColorizePlantSelection(GameObject PlantObject)
    {
        img.GetComponent<Image>().color = new Color(1, 1, 1);   // Sets the color of the image to white to distingish what plant is selected 
    }

    public void ClearAllColorPlantSelection()
    {
        GameObject[] plantImages = GameObject.FindGameObjectsWithTag("InventoryImg");

        foreach (GameObject plantImage in plantImages)
        {
           plantImage.GetComponent<Image>().color = new Color(0.2735849f, 0.2735849f, 0.2735849f);   // Sets the color of the image back to normal

        }
    }
}
