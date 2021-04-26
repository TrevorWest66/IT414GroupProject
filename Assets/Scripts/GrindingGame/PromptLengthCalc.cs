// Trevor West
// 03/28/2021
// Determines how long the key prompt will stay on the screen

public class PromptLengthCalc
{
    public float DeterminePropmptLength(float gameTimer)
    {
        // Sets a default prompt length
        float promptLength = 5f;

        // Sets the prompt length based off of how long the game has been running
        if (gameTimer <= 5)
        {
            promptLength = 5f;
        }
        else if (gameTimer <= 10)
        {
            promptLength = 4f;
        }
        else if (gameTimer <= 15)
        {
            promptLength = 3f;
        }
        else if (gameTimer <= 20)
        {
            promptLength = 2f;
        }
        else if (gameTimer <= 25)
        {
            promptLength = 1f;
        }
        else if (gameTimer <= 30)
        {
            promptLength = .5f;
        }
        else
        {
            promptLength = .3f;
        }

        return promptLength;
    }
}
