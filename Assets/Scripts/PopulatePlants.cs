// Written by Rebecca Henry

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// Singleton
public sealed class PopulatePlants : MonoBehaviour
{
    // Lists all the plants populated on the map
    List<GameObject> PlantsPopulated = new List<GameObject>();

    private readonly static PopulatePlants instance;

    // Private constructor
    private PopulatePlants() { }

    // static constructor
    static PopulatePlants()
    {
        PopulatePlants.instance = new PopulatePlants();
    }

    public static PopulatePlants Instance
    {
        get
        {
            return PopulatePlants.instance;
        }
    }

    // Method to add plants to the list
    public void AddPlant(GameObject aPlant)
    {
        PlantsPopulated.Add(aPlant);
    }

    public GameObject getPlants(int i)
    {
        return PlantsPopulated[i];
    }

}

