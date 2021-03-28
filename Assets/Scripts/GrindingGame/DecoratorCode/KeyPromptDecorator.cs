using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPromptDecorator : IKeyPrompt
{
    private IKeyPrompt _KeyPrompt;

    public KeyPromptDecorator(IKeyPrompt keyPrompt)
    {
        _KeyPrompt = keyPrompt;
    }

    public virtual GameObject GetObjectForSprite()
    {
        return _KeyPrompt.GetObjectForSprite();
    }

    public virtual string GetKeyValue()
    {
        return _KeyPrompt.GetKeyValue();
    }
}
