// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    private GameObject PlantObject; // Generic plant
    private GameObject LavenderPlant = Resources.Load("Lavender") as GameObject;
    private GameObject SpearmintPlant = Resources.Load("Spearmint") as GameObject;
    private GameObject Plant = Resources.Load("flower05") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Generates a random number that will randomly choose which plant spawns
        System.Random random = new System.Random();
        int chance = random.Next(1, 4);

        if (chance == 1) // Creates lavender plant
        {
            // Creates the plant object
            PlantObject = GameObject.Instantiate(LavenderPlant, thePosition, Quaternion.identity);
            // Rename the game object
            PlantObject.name = "Lavender";
        }
        else if(chance == 2) // Creates spearmint plant
        {
            PlantObject = GameObject.Instantiate(SpearmintPlant, thePosition, Quaternion.identity);
            PlantObject.name = "Spearmint";
        }
        else // Creates generic plant
        {
            PlantObject = GameObject.Instantiate(Plant, thePosition, Quaternion.identity);
            PlantObject.name = "Flower";
        }

        // Scales the plants to be larger
        PlantObject.transform.localScale = new Vector3(scale, scale, scale);

        // Adds object to list
        CurrentGameObjects.Instance.addObjectsPopulated(PlantObject);

        return PlantObject;
    }
}
