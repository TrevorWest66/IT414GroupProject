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
        // Will populate a plant if there are less than 50 objects populated
        if (CurrentGameObjects.Instance.getObjectsPopulated().Count < 50)
        {
            aRandomPositionGenerator = new GenerateRandomPosition(WorldTerrain, TerrainLayer);
            Vector3 aRandomPosition = aRandomPositionGenerator.GenerateRandomPositionOnTerrain();

            // Creates a new plant factory which will generate the random plant
            aPlantFactory = new PlantFactory();
            aPlantFactory.CreateGameObject(aRandomPosition, 6f);
        }
    }
}