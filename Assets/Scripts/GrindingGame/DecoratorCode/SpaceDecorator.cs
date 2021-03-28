﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDecorator : KeyPromptDecorator
{
    private readonly float Scale = .15f;
    private string KeyValue = "Space";
    public SpaceDecorator(IKeyPrompt keyPrompt) : base(keyPrompt) { }

    public override GameObject GetObjectForSprite()
    {
        GameObject gameObject = base.GetObjectForSprite();

        //GameObject textObject = GameObject.Instantiate(new GameObject(), gameObject.transform.position, Quaternion.identity);

        GameObject textObject = new GameObject();

        textObject.name = "IndicatedKey";
        textObject.transform.parent = gameObject.transform;
        textObject.transform.position = gameObject.transform.position;
        textObject.transform.localScale = new Vector3(Scale, Scale, Scale);

        TextMesh textRenderer = textObject.AddComponent<TextMesh>();
        textRenderer.text = "Spc";
        textRenderer.fontSize = 36;
        textRenderer.color = new Color(0, 0, 0);
        textRenderer.anchor = TextAnchor.MiddleCenter;

        return gameObject;
    }

    public override string GetKeyValue()
    {
        return KeyValue;
    }
}
