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
                PlantObject = setPlantType("Wheatgrass", ChamomilePlant, thePosition);
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

        TextMesh aPlantName = new TextMesh();

        aPlantName.transform.parent = PlantObject.transform;

        aPlantName.text = PlantName;
        aPlantName.characterSize = .05f;
        aPlantName.anchor = TextAnchor.UpperCenter;

        MeshRenderer aRender = aPlantName.GetComponent<MeshRenderer>();
        //aRender.enabled = false;

        return PlantObject;
    }
}