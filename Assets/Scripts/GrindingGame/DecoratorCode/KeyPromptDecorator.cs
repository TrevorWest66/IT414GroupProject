// Trevor West
// 03/28/2021
// Base decorator

using UnityEngine;

public class KeyPromptDecorator : IKeyPrompt
{
    // A variable for the orginal object
    private IKeyPrompt KeyPrompt;

    // Takes in the orginal object and assigns it to its property;
    public KeyPromptDecorator(IKeyPrompt keyPrompt)
    {
        KeyPrompt = keyPrompt;
    }

    // Calls the GetObjectForSprite on the original object
    public virtual GameObject GetObjectForSprite()
    {
        return KeyPrompt.GetObjectForSprite();
    }

    // Calls the GetKeyValue on the original object
    public virtual string GetKeyValue()
    {
        return KeyPrompt.GetKeyValue();
    }
}
