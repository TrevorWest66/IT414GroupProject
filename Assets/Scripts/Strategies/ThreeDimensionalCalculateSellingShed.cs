// Written by Ellie McDonald
// 04/22/21 
// This class is to help calculate the distance between the player and the selling shed
using UnityEngine;

public class ThreeDimensionalCalculateSellingShed : AbstractCalculate
{
    private bool closeEnough;
    public override bool Calculate(Vector3 locationOne, Vector3 locationTwo)
    {
        double distance = Vector3.Distance(locationOne, locationTwo);

        if (distance <= 5)
        {
            // Is within distance of selling shed
            closeEnough = true;
        }

        else
        {
            // Is not within distance of selling shed
            closeEnough = false;
        }

        return closeEnough;
    }
}
