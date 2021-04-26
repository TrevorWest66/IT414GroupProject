// Trevor West
// 03/28/2021
// Decorator

using UnityEngine;

public class SDecorator : KeyPromptDecorator
{
    // Sets the scale and key value
    private readonly float scale = .25f;
    private readonly string keyValue = "S";
    public SDecorator(IKeyPrompt keyPrompt) : base(keyPrompt) { }

    public override GameObject GetObjectForSprite()
    {
        // Get the sprite from object
        GameObject gameObject = base.GetObjectForSprite();

        // Create a new object for the text
        GameObject textObject = new GameObject();

        // Name the object and attach it to the sprite object as a child and set it's scale
        textObject.name = "IndicatedKey";
        textObject.transform.parent = gameObject.transform;
        textObject.transform.position = gameObject.transform.position;
        textObject.transform.localScale = new Vector3(scale, scale, scale);

        // Adds the text and sets its options
        TextMesh textRenderer = textObject.AddComponent<TextMesh>();
        textRenderer.text = "S";
        textRenderer.fontSize = 85;
        textRenderer.color = new Color(0, 0, 0);
        textRenderer.anchor = TextAnchor.MiddleCenter;
        textRenderer.alignment = TextAlignment.Center;

        // Returns the sprite object
        return gameObject;
    }

    public override string GetKeyValue()
    {
        return keyValue;
    }
}
