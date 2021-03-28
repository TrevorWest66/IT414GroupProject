// Trevor West
// 3/28/2021
// Creates the object for the background of the key prompt

using UnityEngine;

class KeyPrompt : IKeyPrompt
{
    public GameObject SpriteObject;
    private string KeyValue;

    public KeyPrompt(Vector3 thePosition, float scale)
    {
        // Loads the background sprite and gives it a name
        Sprite backGroundSprite = Resources.Load<Sprite>("RequestedKeyImage");
        backGroundSprite.name = "BackGroundSprite";

        // Creates the object for the sprite to go onto
        SpriteObject = new GameObject();
        SpriteObject.transform.position = thePosition;

        //Resizes the background object
        SpriteObject.transform.localScale = new Vector3(scale, scale, scale);

        //Rename the game object
        SpriteObject.name = "KeyPromptImage";

        // Add sprite component and sets sprite
        SpriteRenderer spriteRenderer = SpriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = backGroundSprite;
    }

    // gets the object with the background image that the letter will be attached to
    public GameObject GetObjectForSprite()
    {
        return SpriteObject;
    }

    // gets teh key value
    public string GetKeyValue()
    {
        return KeyValue;
    }
}
