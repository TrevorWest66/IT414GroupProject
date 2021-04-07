// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    private GameObject PlantObject; // Generic plant
    private GameObject AloePlant = Resources.Load("AloePrefab") as GameObject;
    private GameObject ChamomilePlant = Resources.Load("ChamomilePrefab") as GameObject;
    private GameObject ConeFlowerPlant = Resources.Load("ConeFlowerPrefab") as GameObject;
    private GameObject GingerPlant = Resources.Load("GingerPrefab") as GameObject;
    private GameObject LavenderPlant = Resources.Load("LavenderPrefab") as GameObject;
    private GameObject MandrakePlant = Resources.Load("MandrakePrefab") as GameObject;
    private GameObject NightshadePlant = Resources.Load("NightshadePrefab") as GameObject;
    private GameObject RosePlant = Resources.Load("RosePrefab") as GameObject;
    private GameObject SpearmintPlant = Resources.Load("SpearmintPrefab") as GameObject;
    private GameObject WheatgrassPlant = Resources.Load("WheatgrassPrefab") as GameObject;

    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Generates a random number that will randomly choose which plant spawns
        System.Random random = new System.Random();
        int chance = random.Next(1, 11);

        switch (chance) 
        {
            case 1:
                PlantObject = setPlantType("Aloe", AloePlant, thePosition);
                break;
            case 2:
                PlantObject = setPlantType("Chamomile", ChamomilePlant, thePosition);
                break;
            case 3:
                PlantObject = setPlantType("Cone Flower", ConeFlowerPlant, thePosition);
                break;
            case 4:
                PlantObject = setPlantType("Ginger", GingerPlant, thePosition);
                break;
            case 5:
                PlantObject = setPlantType("Lavender", LavenderPlant, thePosition);
                break;
            case 6:
                PlantObject = setPlantType("Mandrake", MandrakePlant, thePosition);
                break;
            case 7:
                PlantObject = setPlantType("Nightshade", NightshadePlant, thePosition);
                break;
            case 8:
                PlantObject = setPlantType("Rose", RosePlant, thePosition);
                break;
            case 9:
                PlantObject = setPlantType("Spearmint", SpearmintPlant, thePosition);
                break;
            default:
                PlantObject = setPlantType("Wheatgrass", WheatgrassPlant, thePosition);
                break;
        }
        
        // Scales the plants to be larger
        PlantObject.transform.localScale = new Vector3(scale, scale, scale);

        // Adds object to list
        CurrentGameObjects.Instance.addObjectsPopulated(PlantObject);

        return PlantObject;
    }

    private GameObject setPlantType(string PlantName, GameObject PlantType, Vector3 thePosition)
    {
        PlantObject = GameObject.Instantiate(PlantType, thePosition, Quaternion.identity);
        PlantObject.name = PlantName;

        // Adds new game object with a text render
        GameObject textObject = new GameObject();

        textObject.name = "Plant Name Text";
        textObject.transform.parent = PlantObject.transform;
        textObject.transform.position = PlantObject.transform.position;

        // Adds text mesh which displays the text
        TextMesh textRenderer = textObject.AddComponent<TextMesh>();
        textRenderer.text = PlantName + "\n(E to pickup)";
        textRenderer.characterSize = .05f;
        textRenderer.alignment = TextAlignment.Center;
        textRenderer.anchor = TextAnchor.UpperCenter;

        // By default the text is not visible
        MeshRenderer aRender = textRenderer.GetComponent<MeshRenderer>();
        aRender.enabled = false;

        // Adds the object text proximity script to the text object
        textObject.AddComponent<ObjectTextProximity>();

        // Adds the collect object script to the Plant object
        PlantObject.AddComponent<CollectObjects>();

        return PlantObject;
    }
}