// Written by Lance Graham
// 03/14/2021
// This is the abstract factory - there are many game objects that can be created

using UnityEngine;

public abstract class AbstractGameObjectFactory
{
    // To create a game object we need to know the position and scale of the game object
    public abstract GameObject CreateGameObject(Vector3 thePosition, float scale);
}
