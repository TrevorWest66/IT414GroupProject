// Trevor West
// 03/28/2021
// Generates a random position for the key prmpt

using UnityEngine;

public class PositionGenerator
{
    private readonly System.Random RandomGenerator = new System.Random();

    public Vector3 GeneratePosition(int xClamp, int yClamp)
    {
        // Gets a random x and y that is within the range of the negative clamp to the positive clamp
        int xPosition = RandomGenerator.Next(-xClamp, xClamp);
        int yPosition = RandomGenerator.Next(-yClamp, yClamp);

        // Creates the vector for the position
        Vector3 position = new Vector3(xPosition, yPosition, 0);

        return position;
    }
}
