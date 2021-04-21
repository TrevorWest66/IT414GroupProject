﻿//Written by Lance Graham
//This is a model responsible for calculating the distance between the player and the cauldron
//The distance determines whether the view should display the crafting button
//This is our first concrete class that follows the strategy pattern
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ThreeDimensionalCalculate : AbstractCalculate
{
    private bool currentDistance;
     public override bool Calculate(Vector3 locationOne, Vector3 locationTwo)
    {
        double distance = Vector3.Distance(locationOne, locationTwo);
    
        if (distance <= 2.5)
        {
            currentDistance = true;
        }

        else
        {
            currentDistance = false;
        }

        return currentDistance;
    }
}