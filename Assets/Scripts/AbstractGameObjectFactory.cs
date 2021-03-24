//Written by Lance Graham
//Factory pattern - there are many game objects that can be created
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractGameObjectFactory
{
    //To create a game object we need to know the position and scale of the game object
    public abstract void CreateGameObject(Vector3 thePosition, float scale);
}
