// Written by Lance Graham
// 04/26/2021
// Used for determining distance between the player and a plant

using UnityEngine;

public class ThreeDimensionalCalculatePlants : AbstractCalculate
{
    private bool currentDistance;
    public override bool Calculate(Vector3 locationOne, Vector3 locationTwo)
    {
        double distance = Vector3.Distance(locationOne, locationTwo);

        if (distance <= 1.75)
        {
            // Is within distance of plant
            currentDistance = true;
        }

        else
        {
            // Is not within distance of plant
            currentDistance = false;
        }

        return currentDistance;
    }
}
