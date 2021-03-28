using System.Collections;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    private AbstractGameObjectFactory aPlantFactory;
    private GenerateRandomPosition aRandomPositionGenerator = new GenerateRandomPosition();

    private void Update()
    {
        if (CurrentGameObjects.Instance.getObjectsPopulated().Count > 100)
        {
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 4f);
        }
    }
    public void spawnPlants(int numPlants)
    {
        for (int i = 0; i < numPlants; i++)
        {
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 4f);
        }
    }

    // put in a void update method
    // create a checker that checkd the number of plants in the objects populated 

    // create method that takes in how many plants you want to create

    // calls the random position generator

    // calls the plant factory

    // add plant to the objects populated list



    // Attach to game controller

}