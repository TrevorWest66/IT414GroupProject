// Written by Rebecca Henry
// 04/11/2021
// Checks the distance between object and player and displays the name when within a certain distance

using UnityEngine;

public class ObjectTextProximity : MonoBehaviour
{
    private AbstractCalculate aCalculate = new ThreeDimensionalCalculatePlants();

    void Update()
    {
        // Finds the player
        GameObject Player = GameObject.FindGameObjectsWithTag("Player")[0];

        // Grabs the plant from the reference
        GameObject Plant = this.gameObject;

        // If the player is within 2.5m of the plant
        if (aCalculate.Calculate(Player.transform.position, Plant.transform.position))
        {
            TextMesh textMesh = Plant.GetComponentInChildren<TextMesh>();
            MeshRenderer aRender = textMesh.GetComponent<MeshRenderer>();

            // positions text to face player
            textMesh.transform.rotation = Player.transform.rotation;
                
            // Makes text visible
            aRender.enabled = true;
        }
        else // Otherwise 
        {
            TextMesh textMesh = Plant.GetComponentInChildren<TextMesh>();
            MeshRenderer aRender = textMesh.GetComponent<MeshRenderer>();
            // Makes text not visible
            aRender.enabled = false;
        }   
    }
}
