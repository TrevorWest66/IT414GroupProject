// Written by Rebecca Henry
using UnityEngine;

public class CollectObjects : MonoBehaviour
{
    private ThreeDimensionalCalculate aCalculate = new ThreeDimensionalCalculate();
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
                // add plant to objects collected dictionary in the singleton
                GameObjects.AddObjectsCollected(Plant);

                // remove plant from list in singleton containing all spawned plants
                GameObjects.RemoveObject(Plant);

                Destroy(Plant);
            }
        }
    }
}
