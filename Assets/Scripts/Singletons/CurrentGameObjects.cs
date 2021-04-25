// Written by Rebecca Henry and Ellie McDonald
// 04/23/21 

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Singleton design pattern
public sealed class CurrentGameObjects
{
    // Lists all the objects populated on the map
    private List<GameObject> objectsPopulated = new List<GameObject>();

    // A dictionary to hold the object name and quantity of object collected
    private Dictionary<string, int> objectsCollected = new Dictionary<string, int>();
    private List<Potion> potionsCrafted = new List<Potion>();

    private readonly static CurrentGameObjects instance;

    // Private constructor
    private CurrentGameObjects() { }

    // static constructor
    static CurrentGameObjects()
    {
        CurrentGameObjects.instance = new CurrentGameObjects();
    }

    public static CurrentGameObjects Instance
    {
        get
        {   //use this keyword when dealing with a single object
            //this variable below is attached to the classname
            return CurrentGameObjects.instance;
        }
    }
    // Method to add objects to the list
    public void addObjectsPopulated(GameObject aPlant)
    {
        objectsPopulated.Add(aPlant);
    }

    public GameObject getObjectPopulated(int i)
    {
        return objectsPopulated[i];
    }

    public List<GameObject> getObjectsPopulated()
    {
        return objectsPopulated;
    }

    public void removeObject(GameObject aPlant)
    {
        objectsPopulated.Remove(aPlant);
    }

    public void removePotion(Potion aPotion)
    {
        this.potionsCrafted.Remove(aPotion);
    }

    //Add objects collected by player
    public void addObjectsCollected(GameObject aPlant)
    {
        string plantName = aPlant.name;

        //Check to see if the key is already in the dictionary
        if (objectsCollected.ContainsKey(plantName))
        {
            int value;
            objectsCollected.TryGetValue(plantName, out value);

            //increment current quantity by 1
            objectsCollected[plantName] = value + 1;
        }
        else
        {
            //Key is not in the dictionary so we add it
            objectsCollected[plantName] = 1;
        }
    }

    //Return the dictionary of objects collected by the player so far
    public Dictionary<string, int> getObjectsCollected()
    {
        return objectsCollected;
    }

    // Return just potions created by the user
    public List<Potion> GetPotionsCreated()
    {
        // All this is just dummy data to populate the potion inventory
        List<Potion> potions = new List<Potion>();

        // Create Strength Potion
        List<CollectablePlantsEnum> strengthPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Rose, CollectablePlantsEnum.Wheatgrass, CollectablePlantsEnum.ConeFlower};

        Potion strengthPotion = new Potion("Strength Potion", 1000, strengthPotionPlantIngredients);

        // Create Speed Potion
        List<CollectablePlantsEnum> speedPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Ginger, CollectablePlantsEnum.ConeFlower, CollectablePlantsEnum.Spearmint};

        Potion speedPotion = new Potion("Speed Potion", 3000, speedPotionPlantIngredients);

        // Create Sleep Potion
        List<CollectablePlantsEnum> sleepPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Lavender, CollectablePlantsEnum.Chamomile, CollectablePlantsEnum.Ginger};

        Potion sleepPotion = new Potion("Sleep Potion", 2000, sleepPotionPlantIngredients);

        potions.Add(strengthPotion);
        potions.Add(speedPotion);
        potions.Add(sleepPotion);

        return potions;

        // Uncomment this once potions are added to the list after the mini game
        // return this.potionsCreated;
    }

    //Count the total number of objects collected thus far
    public int CountObjectsCollected()
    {
        return objectsCollected.Count;
    }
}
