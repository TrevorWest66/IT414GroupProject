using System.Collections;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;

    private AbstractGameObjectFactory aPlantFactory;
    private GenerateRandomPosition aRandomPositionGenerator;

    private void Update()
    {
        if (CurrentGameObjects.Instance.getObjectsPopulated().Count < 50)
        {
            aRandomPositionGenerator = new GenerateRandomPosition(WorldTerrain, TerrainLayer);
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 8f);
        }
    }
   /* public void SpawnPlants(int numPlants)
    {
        aRandomPositionGenerator = new GenerateRandomPosition(WorldTerrain, TerrainLayer);

        for (int i = 0; i < numPlants; i++)
        {
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 4f);
        }
    }*/
}