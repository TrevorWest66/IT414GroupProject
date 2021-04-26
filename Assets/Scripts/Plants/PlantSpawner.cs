// Written by Rebecca Henry
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;

    private AbstractGameObjectFactory aPlantFactory;
    private GenerateRandomPosition aRandomPositionGenerator;

    void Update()
    {
        // Will populate a plant if there are less than 50 objects populated
        if (CurrentGameObjects.Instance.GetObjectsPopulated().Count < 75)
        {
            aRandomPositionGenerator = new GenerateRandomPosition(WorldTerrain, TerrainLayer);
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            // Creates a new plant factory which will generate the random plant
            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 6f);
        }
    }
}