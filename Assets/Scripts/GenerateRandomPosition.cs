using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRandomPosition : MonoBehaviour
{
    public Terrain WorldTerrain;
    public LayerMask TerrainLayer;
    public static float TerrainLeft, TerrainRight, TerrainTop, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight;

    public static ArrayList units = new ArrayList();
    public static ArrayList positions = new ArrayList();
    public static ArrayList rotations = new ArrayList();

    private void Awake()
    {
        // Terrain is set smaller than it actually is so plants are spawned more in the center
        TerrainLeft = -200;
        TerrainBottom = -200;
        TerrainWidth = 400;
        TerrainLength = 400;
        TerrainHeight = 300;
        TerrainRight = TerrainLeft + TerrainWidth;
        TerrainTop = TerrainBottom + TerrainLength;
    }

    // Takes in the game object, how many you want, moves item up vertically
    public Vector3 GenerateRandomPositionOnTerrain()
    {
        float addedHeight = .1f;
        float terrainHeight = 0f;
        RaycastHit hit;
        float randomPositionX, randomPositionY, RandomPositionZ;
        Vector3 randomPosition = Vector3.zero;
        
        randomPositionX = Random.Range(TerrainLeft, TerrainRight);
        RandomPositionZ = Random.Range(TerrainBottom, TerrainTop);

        if (Physics.Raycast(new Vector3(randomPositionX, 99999f, RandomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
        {
            terrainHeight = hit.point.y;
        }

        // Prevents position from being set up too high
        if (terrainHeight < 40)
        {
            randomPositionY = terrainHeight + addedHeight;

            randomPosition = new Vector3(randomPositionX, randomPositionY, RandomPositionZ);
        }

        /*// check position of the plant and verify there is not already a plant there
        foreach(GameObject p in CurrentGameObjects.Instance.getObjectsPopulated())
        {
            if (p.transform.position == randomPosition);
            {
                GenerateRandomPositionOnTerrain();
            }
        }*/

        return randomPosition;
    }
}
