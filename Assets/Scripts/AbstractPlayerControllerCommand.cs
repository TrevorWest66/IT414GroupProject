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
        float hMove = 0.0f;
        float vMove = 5.0f;
        float speed = 10.0f;

        Vector3 aMove = aCharacter.transform.forward * vMove + aCharacter.transform.right * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
        hMove = 0.0f;
        vMove = 0.0f;
    }
}

public class MoveBack : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        float hMove = 0.0f;
        float vMove = -5.0f;
        float speed = 10.0f;

        Vector3 aMove = aCharacter.transform.forward * vMove + aCharacter.transform.right * hMove;
        aController.Move(aMove * Time.deltaTime * speed);
        hMove = 0.0f;
        vMove = 0.0f;
    }
}

public class TurnLeft : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        aCharacter.transform.Rotate(0.0f, -20.0f, 0.0f);
    }
}

public class TurnRight : AbstractPlayerControllerCommand
{
    public override void Execute(GameObject aCharacter, CharacterController aController)
    {
        aCharacter.transform.Rotate(0.0f, 20.0f, 0.0f);
    }
}

//This will jump the player in the air (up and down) and hold for a brief second
//before dropping the player back onto the plane. 
public class JumpUp : AbstractPlayerControllerCommand
{
    public override async void Execute(GameObject aCharacter, CharacterController aController)
    {
        float yMove = 13.0f;

        aCharacter.transform.position = new Vector3(aCharacter.transform.position.x, aCharacter.transform.position.y + yMove, aCharacter.transform.position.z);
        await WaitJump(0.2f);
        aCharacter.transform.position = new Vector3(aCharacter.transform.position.x, aCharacter.transform.position.y + (0 - yMove), aCharacter.transform.position.z);
    }

    private async Task WaitJump(float wait)
    {
        await Task.Delay(System.TimeSpan.FromSeconds(wait));
        // Debug.Log("I waited");
    }
}
