// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    public override void CreateGameObject(Vector3 thePosition, int scale)
    {
        // Replace this with the plant obj
        GameObject thePlant = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        thePlant.transform.localScale = new Vector3(scale, scale, scale);
        thePlant.transform.position = thePosition;

    }
}
