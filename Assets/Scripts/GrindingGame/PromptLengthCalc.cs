// Trevor West
// 3/28/2021

public class PromptLengthCalc
{
    public float DeterminePropmptLength(float gameTimer)
    {
        // sets a default prompt length
        float promptLength = 5f;

        // sets teh prompt length based off of how long the game has been running
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
