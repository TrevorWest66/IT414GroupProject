// Written by Rebecca Henry
// 04/11/2021
// This class is used to pickup and destroy the picked up plant in the game

using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private AbstractCalculate aCalculate = new ThreeDimensionalCalculatePlants();
    private CurrentGameObjects GameObjects = CurrentGameObjects.Instance;

    void Update()
    {
        // Finds the player
        GameObject Player = GameObject.FindGameObjectsWithTag("Player")[0];

        // Grabs the plant from the reference
        GameObject Plant = this.gameObject;

        // If the player is within 2.5m of the plant
        if (aCalculate.Calculate(Player.transform.position, Plant.transform.position))
        {
            // Checks if player wants to pickup the object
            if (Input.GetKey("e"))
            {
                // Add plant to objects collected dictionary in the singleton
                GameObjects.AddObjectsCollected(Plant);

                // Remove plant from list in singleton containing all spawned plants
                GameObjects.RemoveObject(Plant);

                Destroy(Plant);
            }
        }
    }
}
