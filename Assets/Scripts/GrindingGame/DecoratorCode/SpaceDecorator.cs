// Trevor West
// 3/28/2021
// Decorator

using UnityEngine;

public class SpaceDecorator : KeyPromptDecorator
{
    // sets the scale and key value
    private readonly float scale = .15f;
    private readonly string keyValue = "Space";
    public SpaceDecorator(IKeyPrompt keyPrompt) : base(keyPrompt) { }

    public override GameObject GetObjectForSprite()
    {
        // get the sprite from object
        GameObject gameObject = base.GetObjectForSprite();

        // create a new object for the text
        GameObject textObject = new GameObject();

        // name the object and attach it to the sprite object as a child and set it's scale
        textObject.name = "IndicatedKey";
        textObject.transform.parent = gameObject.transform;
        textObject.transform.position = gameObject.transform.position;
        textObject.transform.localScale = new Vector3(scale, scale, scale);

        // Adds the text and sets its options
        TextMesh textRenderer = textObject.AddComponent<TextMesh>();
        textRenderer.text = "Spc";
        textRenderer.fontSize = 36;
        textRenderer.color = new Color(0, 0, 0);
        textRenderer.anchor = TextAnchor.MiddleCenter;

        // returns the sprite object
        return gameObject;
    }

    public override string GetKeyValue()
    {
        return keyValue;
    }
}
