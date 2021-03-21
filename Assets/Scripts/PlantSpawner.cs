using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlantSpawner : MonoBehaviour
    {

        public Terrain WorldTerrain;
        public LayerMask TerrainLayer;
        public static float TerrainLeft, TerrainRight, TerrainTop, TerrainBottom, TerrainWidth, TerrainLength, TerrainHeight;

        public static ArrayList units = new ArrayList();
        public static ArrayList positions = new ArrayList();
        public static ArrayList rotations = new ArrayList();


        private void Awake()
        {
            TerrainLeft = WorldTerrain.transform.position.x;
            TerrainBottom = WorldTerrain.transform.position.z;
            TerrainWidth = WorldTerrain.terrainData.size.x;
            TerrainLength = WorldTerrain.terrainData.size.z;
            TerrainHeight = WorldTerrain.terrainData.size.y;
            TerrainRight = TerrainLeft + TerrainWidth;
            TerrainTop = TerrainBottom + TerrainLength;

            InstatntiateRandomPosition("flower05", 20, 0f);

        }


        public void InstatntiateRandomPosition(string Resource, int Amount, float AddedHeight)
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

                randomPositionY = terrainHeight + AddedHeight;

                randomPosition = new Vector3(randomPositionX, randomPositionY, RandomPositionZ);

                Instantiate(Resources.Load(Resource, typeof(GameObject)), randomPosition, Quaternion.identity);



            } while (i < Amount);


        }

    }
}
