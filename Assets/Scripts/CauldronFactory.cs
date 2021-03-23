using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronFactory : AbstractGameObjectFactory
{
    private GameObject cauldron = Resources.Load("Cauldron2") as GameObject;
    public override void CreateGameObject(Vector3 thePosition, float scale)
    {
        cauldron = GameObject.Instantiate(cauldron, thePosition, Quaternion.identity);

        cauldron.transform.localScale = new Vector3(scale, scale, scale);
    }
}
