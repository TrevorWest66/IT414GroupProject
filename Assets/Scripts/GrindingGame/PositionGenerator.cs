// Trevor West
// 3/28/2021

using UnityEngine;

public class PositionGenerator
{
    private readonly System.Random RandomGenerator = new System.Random();

    public Vector3 GeneratePosition(int xClamp, int yClamp)
    {
        // gets a random x and y that is within the range of the negative clamp to the positive clamp
        int xPosition = RandomGenerator.Next(-xClamp, xClamp);
        int yPosition = RandomGenerator.Next(-yClamp, yClamp);

        // creates the vector for the position
        Vector3 position = new Vector3(xPosition, yPosition, 0);

        return position;
    }
}
