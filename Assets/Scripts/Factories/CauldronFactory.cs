﻿// Written by Lance Graham
// 03/14/2021
// This is a concrete factory responsible for creating the crafting station, aka the cauldron

using UnityEngine;

public class CauldronFactory : AbstractGameObjectFactory
{
    // Load the prefab cauldron
    private GameObject cauldron = Resources.Load("CauldronPrefab") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Instantiate the object at the vector passed in
        cauldron = GameObject.Instantiate(cauldron, thePosition, Quaternion.identity);

        // Resize the cauldron
        cauldron.transform.localScale = new Vector3(scale, scale, scale);

        // Prevent other objects from passing through cauldron
        cauldron.AddComponent<BoxCollider>();

        // Rename the game object
        cauldron.name = "Cauldron";

        return cauldron;
    }
}
