// Written by Rebecca Henry

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Singleton design pattern
public sealed class CurrentGameObjects : MonoBehaviour
{
    // Lists all the objects populated on the map
    private List<GameObject> objectsPopulated = new List<GameObject>();

    // A dictionary to hold the object name and quantity of object collected
    private Dictionary<string, int> objectsCollected = new Dictionary<string, int>();

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
}
