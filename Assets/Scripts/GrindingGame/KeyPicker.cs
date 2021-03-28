// Trevor West
// 3/28/2021

public class KeyPicker
{
    System.Random RandomGenerator = new System.Random();
    private IKeyPrompt decorator;

    public IKeyPrompt PickKeyPrompt(IKeyPrompt keyPromptDecorator)
    {
        // creates a random number between 0 and 4 (inclusivve)
        int chosenNum = RandomGenerator.Next(5);

        // picks a decorator for adding the key image based of the random numbner
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

        // returns the chosen decroator
        return decorator;

    }
}
