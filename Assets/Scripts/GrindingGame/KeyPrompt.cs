using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class KeyPrompt : IKeyPrompt
{
    public GameObject SpriteObject;
    private string KeyValue;

    public KeyPrompt(Vector3 thePosition, float scale)
    {
        //Instantiate the object at the vector passed in
        Sprite backGroundSprite = Resources.Load<Sprite>("RequestedKeyImage");
        backGroundSprite.name = "BackGroundSprite";

        // SpriteObject = GameObject.Instantiate(new GameObject(), thePosition, Quaternion.identity);
        SpriteObject = new GameObject();
        SpriteObject.transform.position = thePosition;

        //Resize the cauldron
        SpriteObject.transform.localScale = new Vector3(scale, scale, scale);

        //Rename the game object
        SpriteObject.name = "KeyPromptImage";

        // Add sprite component
        SpriteRenderer spriteRenderer = SpriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = backGroundSprite;
    }

    public GameObject GetObjectForSprite()
    {
        return SpriteObject;
    }

    public string GetKeyValue()
    {
        return KeyValue;
    }
}
