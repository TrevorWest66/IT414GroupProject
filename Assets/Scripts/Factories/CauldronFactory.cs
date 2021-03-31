//Written by Lance Graham
//This is a concrete factory responsible for creating the crafting station, aka the cauldron
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFactory : AbstractGameObjectFactory
{
    //Load the prefab cauldron
    private GameObject cauldron = Resources.Load("CauldronPrefab") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        //Instantiate the object at the vector passed in
        cauldron = GameObject.Instantiate(cauldron, thePosition, Quaternion.identity);

        //Resize the cauldron
        cauldron.transform.localScale = new Vector3(scale, scale, scale);

        //Rename the game object
        cauldron.name = "Cauldron";

        return cauldron;
    }
}
