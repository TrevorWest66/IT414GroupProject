// Written by Ellie McDonald
// 03/15/21
// Abstract Command class, used command pattern call player movemennts

using UnityEngine;
using System.Threading.Tasks;

public abstract class AbstractPlayerControllerCommand
{
    public abstract void Execute(GameObject aCharacter, CharacterController aController);
}

public class MoveForward : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        float hMove = 5.0f;
        float speed = 2.0f;

        Vector3 aMove = aCharacter.transform.forward * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
    }
}

public class MoveBack : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        float hMove = -5.0f;
        float speed = 2.0f;

        Vector3 aMove = aCharacter.transform.forward * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
    }
}

public class TurnLeft : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        float hMove = -5.0f;
        float speed = 2.0f;

        Vector3 aMove = aCharacter.transform.right * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
    }
}

public class TurnRight : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        float hMove = 5.0f;
        float speed = 2.0f;

        Vector3 aMove = aCharacter.transform.right * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
    }
}

// This will jump the player in the air (up and down) and hold for a brief second
// before dropping the player back onto the plane. 
public class JumpUp : AbstractPlayerControllerCommand
{
    public override async void Execute(GameObject aCharacter, CharacterController aController)
    {
        float yMove = 13.0f;

        aCharacter.transform.position = new Vector3(aCharacter.transform.position.x, aCharacter.transform.position.y + yMove, aCharacter.transform.position.z);
        await WaitJump(0.2f);
    }

    private async Task WaitJump(float wait)
    {
        await Task.Delay(System.TimeSpan.FromSeconds(wait));
    }
}
