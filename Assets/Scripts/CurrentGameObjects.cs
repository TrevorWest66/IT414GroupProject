// Written by Rebecca Henry

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Singleton
public sealed class CurrentGameObjects : MonoBehaviour
{
    // Lists all the objects populated on the map
    List<GameObject> ObjectsPopulated = new List<GameObject>();

    private static CurrentGameObjects instance;

    // Private constructor
    private CurrentGameObjects() { }

    // static constructor
    public static CurrentGameObjects Instance()
    {
        if (instance = null)
        {
            CurrentGameObjects.instance = new CurrentGameObjects();
        }
        return CurrentGameObjects.instance;
    }

    // Method to add objects to the list
    public void AddObjects(GameObject aPlant)
    {
        ObjectsPopulated.Add(aPlant);
    }

    public GameObject getObjects(int i)
    {
        return ObjectsPopulated[i];
    }

}

