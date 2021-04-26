// Written by Rebecca Henry, Ellie McDonald, and Lance Graham
// 04/23/21 
// A singleton for the objects in the game based on the player's interaction

using System.Collections.Generic;
using UnityEngine;

// Singleton design pattern
public sealed class CurrentGameObjects
{
    // List containing the objects populated on the map
    private List<GameObject> objectsPopulated = new List<GameObject>();

    // List for ingredients of a potion
    public List<string> Ingredients { get; set; } = new List<string>();

    // A dictionary to hold the object name and quantity of object collected
    private Dictionary<string, int> objectsCollected = new Dictionary<string, int>();

    // List for potions crafted thus far
    private List<Potion> potionsCrafted = new List<Potion>();

    private readonly static CurrentGameObjects instance;

    // Private constructor
    private CurrentGameObjects() { }
     
    // Static constructor will be called only when needed
    static CurrentGameObjects()
    {
        CurrentGameObjects.instance = new CurrentGameObjects();
    }

    // Getter to get the one instance of this object
    public static CurrentGameObjects Instance
    {
        get
        {   // Use "this." keyword when dealing with a single object
            // This variable below is attached to the classname
            return CurrentGameObjects.instance;
        }
    }
    // Method to add objects to the list of objects populated on the map
    public void AddObjectsPopulated(GameObject aPlant)
    {
        objectsPopulated.Add(aPlant);
    }

    // Get an object populated on the map
    public GameObject GetObjectPopulated(int i)
    {
        return objectsPopulated[i];
    }

    // Return all objects populated on map
    public List<GameObject> GetObjectsPopulated()
    {
        return objectsPopulated;
    }

    // Remove game object from the current list of objects populated
    public void RemoveObject(GameObject aPlant)
    {
        objectsPopulated.Remove(aPlant);
    }

    // Remove potion from the list of potions crafted by player
    public void RemovePotion(Potion aPotion)
    {
        this.potionsCrafted.Remove(aPotion);
        objectsCollected.Remove(aPotion.keyName);
    }

    // Add a potion to the list of potions crafted by player
    public void AddPotion(Potion aPotion)
    {
        this.potionsCrafted.Add(aPotion);
    }

    // Add plant gameobject object collected by player
    public void AddObjectsCollected(GameObject aPlant)
    {
        string plantName = aPlant.name;

        // Check to see if the key is already in the dictionary
        if (objectsCollected.ContainsKey(plantName))
        {
            int value;
            objectsCollected.TryGetValue(plantName, out value);

            // Increment current quantity by 1
            objectsCollected[plantName] = value + 1;
        }
        else
        {
            // Key is not in the dictionary so we add it
            objectsCollected[plantName] = 1;
        }
    }
    
    // Remove object collected by player
    public void RemoveObjectCollected(GameObject aPlant)
    {
        string plantName = aPlant.name;

        // Check to see if the key is already in the dictionary
        if (objectsCollected.ContainsKey(plantName))
        {
            int value;
            objectsCollected.TryGetValue(plantName, out value);

            // Decrease current quantity by 1
            objectsCollected[plantName] = value - 1;
        }
    }

    // Add to objects collected by player
    public void AddObjectsCollected(string key, int quantity)
    {
        objectsCollected[key] = quantity;
    }

    // Return the dictionary of objects collected by the player so far
    public Dictionary<string, int> getObjectsCollected()
    {
        return objectsCollected;
    }

    // Return the potions created by the user
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

    // Count the total number of objects collected thus far
    public int CountObjectsCollected()
    {
        return objectsCollected.Count;
    }
}
