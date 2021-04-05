using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTextProximity : MonoBehaviour
{
    private ThreeDimensionalCalculate aCalculate = new ThreeDimensionalCalculate();
    private CurrentGameObjects GameObjects = CurrentGameObjects.Instance;

    void Update()
    {
        // Finds the player
        GameObject Player = GameObject.FindGameObjectsWithTag("Player")[0];

        // Grabs this list of plants from the singleton
        List<GameObject> Plants = GameObjects.getObjectsPopulated();

        for (int i = 0; i < Plants.Count; i ++)
        {
            // If the player is within 2.5m of the plant
            if (aCalculate.Calculate(Player.transform.position, Plants[i].transform.position))
            {
              
                //GameObject plantText = GameObject.Find("Plant Name Text");
                //plantText.transform.position = new Vector3(-plantText.transform.position.x, plantText.transform.position.y, plantText.transform.position.z);

                TextMesh textMesh = Plants[i].GetComponentInChildren<TextMesh>();
                MeshRenderer aRender = textMesh.GetComponent<MeshRenderer>();

                //Vector3 playerPosition = Player.transform.position;

                //playerPosition = new Vector3(-Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);

                textMesh.transform.LookAt(Player.transform.position);
                
                // Makes text visible
                aRender.enabled = true;
            }
            else // Otherwise 
            {
                TextMesh textMesh = Plants[i].GetComponentInChildren<TextMesh>();
                MeshRenderer aRender = textMesh.GetComponent<MeshRenderer>();
                // Makes text not visible
                aRender.enabled = false;
            }
        }
    }
}
