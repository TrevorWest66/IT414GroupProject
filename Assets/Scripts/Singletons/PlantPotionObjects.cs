// Written by Rebecca Henry
// 4/25/21
using System.Collections.Generic;
using UnityEngine;

public sealed class PlantPotionObjects
{
    // Lists all the objects populated on the map
    private List<GameObject> potionIngredients = new List<GameObject>();

    private readonly static PlantPotionObjects instance;

    // Private Constructor
    private PlantPotionObjects() { }

    // Static Constructor
    static PlantPotionObjects()
    {
        PlantPotionObjects.instance = new PlantPotionObjects();
    }

    public static PlantPotionObjects Instance
    {
        get
        {   //use this keyword when dealing with a single object
            //this variable below is attached to the classname
            return PlantPotionObjects.instance;
        }
    }

    // Method to add objects to the list
    public void addPlantInPotion(GameObject aPlant)
    {
        // if there is already 3 plants selected, remove the last plant and add the plant most recent plant
        if(potionIngredients.Count == 3)
        {
            potionIngredients.RemoveAt(2);
        }
        
        potionIngredients.Add(aPlant);
    }

    public GameObject getPlantInPotion(int i)
    {
        return potionIngredients[i];
    }

    public List<GameObject> getPlantsInPotion()
    {
        return potionIngredients;
    }

    public void removePlantInPotion(GameObject aPlant)
    {
        potionIngredients.Remove(aPlant);
    }

    public void removeAllPlantsInPotion()
    {
        for (int i = plantsInPotionCount(); i > 0; i--)
        {
            potionIngredients.Clear();
        }
       
    }

    public int plantsInPotionCount()
    {
        return potionIngredients.Count;
    }

}
