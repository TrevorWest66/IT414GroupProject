// Written by Rebecca Henry
// 04/11/2021
// Used to generate a random location on the terrain that will be used for spawning plants

using System.Collections;
using UnityEngine;

public class GenerateRandomPosition
{
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;
    public static float TerrainLeft, TerrainRight, TerrainTop, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight;

    public static ArrayList units = new ArrayList();
    public static ArrayList positions = new ArrayList();
    public static ArrayList rotations = new ArrayList();

    public GenerateRandomPosition(Terrain worldTerrain, LayerMask terrainLayer)
    {
        // Terrain is set smaller than it actually is so plants are spawned more in the center
        TerrainLeft = -200;
        TerrainBottom = -200;
        TerrainWidth = 400;
        TerrainLength = 400;
        TerrainHeight = 300;
        TerrainRight = TerrainLeft + TerrainWidth;
        TerrainTop = TerrainBottom + TerrainLength;

        WorldTerrain = worldTerrain;
        TerrainLayer = terrainLayer;
    }

    public Vector3 GenerateRandomPositionOnTerrain()
    {
        float addedHeight = .2f;
        float terrainHeight = 0f;
        RaycastHit hit;
        float randomPositionX, randomPositionY, RandomPositionZ;
        Vector3 randomPosition = Vector3.zero;
        
        // Generates a random number within the bound of the terrain
        randomPositionX = Random.Range(TerrainLeft, TerrainRight);
        RandomPositionZ = Random.Range(TerrainBottom, TerrainTop);

        if (Physics.Raycast(new Vector3(randomPositionX, 99999f, RandomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
        {
            terrainHeight = hit.point.y;
        }

        // If the position is under 40, set it as the position
        if (terrainHeight < 40)
        {
            randomPositionY = terrainHeight + addedHeight;

            randomPosition = new Vector3(randomPositionX, randomPositionY, RandomPositionZ);
        }
        // If the position generated is above 40, generate a new position
        else
        {
            GenerateRandomPositionOnTerrain();
        }

        // Prevents default location from spawning plants
        if (randomPosition.Equals(new Vector3(0, 0, 0)))
        {
            randomPosition = GenerateRandomPositionOnTerrain();
        }

        return randomPosition;
    }
}
