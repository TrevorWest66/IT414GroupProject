// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    private GameObject PlantObject = Resources.Load("flower05") as GameObject;

    public override void CreateGameObject(Vector3 thePosition, float scale)
    {
        // Scales the plants to be larger
        PlantObject.transform.localScale = new Vector3(scale, scale, scale);

        // Instantiate the object at the vector passed in
        PlantObject = GameObject.Instantiate(PlantObject, thePosition, Quaternion.identity);

        // Rename the game object
        PlantObject.name = "Flower";

        // Adds object to list
        CurrentGameObjects.Instance.addObjectsPopulated(PlantObject);

    }
}
