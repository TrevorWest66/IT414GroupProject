using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PromptLengthCalc
{
    public float DeterminePropmptLength(float gameTimer)
    {
        float promptLength = 0f;

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
