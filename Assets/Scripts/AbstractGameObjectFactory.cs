//Written by Lance Graham
//Factory pattern -  there are many gameobjects that can be created
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractGameObjectFactory
{
    public abstract void CreateGameObject(Vector3 thePosition, int scale);
}
