// Written by Lance Graham
// 03/01/2021
// Used for calculating the distance between the player and the cauldron.
// The distance determines whether the view should display the crafting button.
// This is our first concrete class that follows the strategy pattern.

using UnityEngine;

public class ThreeDimensionalCalculateCrafting : AbstractCalculate
{
    private bool currentDistance;
     public override bool Calculate(Vector3 locationOne, Vector3 locationTwo)
    {
        double distance = Vector3.Distance(locationOne, locationTwo);
    
        if (distance <= 2)
        {
            // Is within distance of cauldron
            currentDistance = true;
        }

        else
        {
            // Is not within distanc of cauldron
            currentDistance = false;
        }

        return currentDistance;
    }
}
