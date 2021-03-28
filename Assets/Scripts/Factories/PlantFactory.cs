// Written by Rebecca Herny
// Creates the plants
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantFactory : AbstractGameObjectFactory
{
    public override GameObject CreateGameObject(Vector3 thePosition, float scale)
    {
        // Replace this with the plant obj
        GameObject thePlant = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        thePlant.transform.localScale = new Vector3(scale, scale, scale);
        thePlant.transform.position = thePosition;

        return thePlant;
    }
}
