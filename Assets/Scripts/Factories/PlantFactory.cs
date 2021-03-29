// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    private GameObject PlantObject; // Generic plant
    private GameObject LavenderPlant = Resources.Load("LavenderPrefab") as GameObject;
    private GameObject SpearmintPlant = Resources.Load("SpearmintPrefab") as GameObject;
    private GameObject RosePlant = Resources.Load("RosePrefab") as GameObject;
    private GameObject ChamomilePlant = Resources.Load("ChamomilePrefab") as GameObject;
    private GameObject AloePlant = Resources.Load("AloePrefab") as GameObject;
    private GameObject Plant = Resources.Load("flower05") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Generates a random number that will randomly choose which plant spawns
        System.Random random = new System.Random();
        int chance = random.Next(1, 6);

        if (chance == 1) // Creates lavender plant
        {
            // Creates the plant object
            PlantObject = GameObject.Instantiate(LavenderPlant, thePosition, Quaternion.identity);
            // Rename the game object
            PlantObject.name = "Lavender";

            // Adds text to plant to say what it is
            TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            aPlantName.text = "Lavender";
            aPlantName.characterSize = .05f;
            aPlantName.anchor = TextAnchor.UpperCenter;

            // Access the mesh render which allows you to change if you want it displayed
            MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;

        }
        else if(chance == 2) // Creates spearmint plant
        {
            PlantObject = GameObject.Instantiate(SpearmintPlant, thePosition, Quaternion.identity);
            PlantObject.name = "Spearmint";

            TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            aPlantName.text = "Spearmint";
            aPlantName.characterSize = .05f;
            aPlantName.anchor = TextAnchor.UpperCenter;

            MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;
        }
        else if (chance == 3) // Creates rose plant
        {
            PlantObject = GameObject.Instantiate(RosePlant, thePosition, Quaternion.identity);
            PlantObject.name = "Rose";

            TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            aPlantName.text = "Rose";
            aPlantName.characterSize = .05f;
            aPlantName.anchor = TextAnchor.UpperCenter;

            MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;
        }
        else if (chance == 4) // Creates chamomile plant
        {
            PlantObject = GameObject.Instantiate(ChamomilePlant, thePosition, Quaternion.identity);
            PlantObject.name = "Chamomile";

            //TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            //aPlantName.text = "Chamomile";
            //aPlantName.characterSize = .05f;
            //aPlantName.anchor = TextAnchor.UpperCenter;

            //MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;
        }
        else if (chance == 4) // Creates aloe plant
        {
            PlantObject = GameObject.Instantiate(AloePlant, thePosition, Quaternion.identity);
            PlantObject.name = "Aloe";

            TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            aPlantName.text = "Aloe";
            aPlantName.characterSize = .05f;
            aPlantName.anchor = TextAnchor.UpperCenter;

            MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;
        }
        else // Creates generic plant
        {
            PlantObject = GameObject.Instantiate(Plant, thePosition, Quaternion.identity);
            PlantObject.name = "Flower";

            TextMesh aPlantName = PlantObject.AddComponent<TextMesh>();
            aPlantName.text = "Flower";
            aPlantName.characterSize = .05f;
            aPlantName.anchor = TextAnchor.UpperCenter;

            MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
            //aRender.enabled = false;
        }

        // Scales the plants to be larger
        PlantObject.transform.localScale = new Vector3(scale, scale, scale);

        // Adds object to list
        CurrentGameObjects.Instance.addObjectsPopulated(PlantObject);

        return PlantObject;
    }
}
