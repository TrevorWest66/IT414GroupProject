using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPicker
{
    System.Random RandomGenerator = new System.Random();
    private IKeyPrompt decorator;

    public IKeyPrompt PickKeyPrompt(IKeyPrompt keyPromptDecorator)
    {
        int chosenNum = RandomGenerator.Next(5);

        if (chosenNum.Equals(0))
        {
            decorator = new WDecorator(keyPromptDecorator);
        }
        else if (chosenNum.Equals(1))
        {
            decorator = new ADecorator(keyPromptDecorator);
        }
        else if (chosenNum.Equals(2))
        {
            decorator = new SDecorator(keyPromptDecorator);
        }
        else if (chosenNum.Equals(3))
        {
            decorator = new DDecorator(keyPromptDecorator);
        }
        else
        {
            decorator = new SpaceDecorator(keyPromptDecorator);
        }

        return decorator;

    }
}
