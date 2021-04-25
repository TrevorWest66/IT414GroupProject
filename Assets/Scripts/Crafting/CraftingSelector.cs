using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSelector : MonoBehaviour
{
    public Image img; // Need to find the image in each slot
    public List<GameObject> PotionIngredients;

    public void PlantToCraftPotion()
    {
        string PlantName = img.GetComponent<Image>().sprite.name;
        GameObject PlantObject = GameObject.Find(PlantName); // Finds the plant gameobject

        PotionIngredients.Add(PlantObject); // Adds to potion ingredient list
        CurrentGameObjects.Instance.removeObject(PlantObject);  // Removes the plant from the inventory

        Debug.Log("Plant added to list");

    }

}
