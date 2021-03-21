using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlantSpawner : MonoBehaviour
    {
        public Terrain WorldTerrain;
        public LayerMask TerrainLayer;
        public GameObject PlantObject;
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

            // Scales the plants to be larger
            PlantObject.transform.localScale = new Vector3(4, 4, 4);

            // Have to add height as a result of the scaling
            InstatntiateRandomPosition(PlantObject, 100, 0.1f);
        }

        // Takes in the game object, how many you want, moves item up vertically
        public void InstatntiateRandomPosition(GameObject aPlant, int Amount, float AddedHeight)
        {
            var i = 0;
            float terrainHeight = 0f;
            RaycastHit hit;
            float randomPositionX, randomPositionY, RandomPositionZ;
            Vector3 randomPosition = Vector3.zero;

            do
            {
                i++;
                randomPositionX = Random.Range(TerrainLeft, TerrainRight);
                RandomPositionZ = Random.Range(TerrainBottom, TerrainTop);

                if(Physics.Raycast(new Vector3(randomPositionX, 99999f, RandomPositionZ), Vector3.down, out hit, Mathf.Infinity, TerrainLayer))
                {
                    terrainHeight = hit.point.y;
                }

                // Prevents plant from being spawned up too high
                if(terrainHeight < 40)
                {
                    randomPositionY = terrainHeight + AddedHeight;

                    randomPosition = new Vector3(randomPositionX, randomPositionY, RandomPositionZ);

                    Instantiate(aPlant, randomPosition, Quaternion.identity);
                }

            } while (i < Amount);
        }
    }
}
