using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGenerator
{
    private readonly System.Random RandomGenerator = new System.Random();

    public Vector3 GeneratePosition(int xClamp, int yClamp)
    {
        int xPosition = RandomGenerator.Next(-xClamp, xClamp);
        int yPosition = RandomGenerator.Next(-yClamp, yClamp);
        Vector3 position = new Vector3(xPosition, yPosition, 0);

        return position;
    }
}
