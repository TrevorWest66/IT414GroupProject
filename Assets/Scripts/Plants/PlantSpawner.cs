// Written by Rebecca Henry
// 04/07/2021
// Spawn the plants on the terrain

using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;

    private AbstractGameObjectFactory aPlantFactory;
    private GenerateRandomPosition aRandomPositionGenerator;

    void Update()
    {
        // Will populate a plant if there are less than 75 objects populated
        if (CurrentGameObjects.Instance.GetObjectsPopulated().Count < 75)
        {
            // Generate a random position on the world terrain for the new plant
            aRandomPositionGenerator = new GenerateRandomPosition(WorldTerrain, TerrainLayer);
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            // Creates a new plant factory which will generate the random plant
            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 6f);
        }
    }
}