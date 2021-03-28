// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    private GameObject PlantObject = Resources.Load("flower05") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Instantiate the object at the vector passed in
        PlantObject = GameObject.Instantiate(PlantObject, thePosition, Quaternion.identity);

        // Scales the plants to be larger
        PlantObject.transform.localScale = new Vector3(scale, scale, scale);

        // Rename the game object
        PlantObject.name = "Flower";

        // Adds object to list
        CurrentGameObjects.Instance.addObjectsPopulated(PlantObject);

        return PlantObject;
        
    }
}
