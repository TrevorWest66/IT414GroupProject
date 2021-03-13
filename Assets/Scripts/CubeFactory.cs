using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : AbstractGameObjectFactory
{
    public override void CreateGameObject(Vector3 thePosition, int scale)
    {
        GameObject theCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        theCube.transform.localScale = new Vector3(scale, scale, scale);
        theCube.transform.position = thePosition;
    }
}
