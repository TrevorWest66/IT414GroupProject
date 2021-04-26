// Written by Lance Graham & Ellie McDonald
// 03/19/2021
// This class is responsible for coordinating the character's movement

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Navigator : MonoBehaviour
{
    public List<KeyCode> controllerKeys;
    AbstractPlayerControllerCommand keyLeft, keyRight, keyForward, keyBack, keyJump;
    public CharacterController aCharacterController;

    // Dictates which controls will be used
    private BuilderDirector builderDirector = new BuilderDirector();
    private PlayerControlsBuilder controlsBuilder;
    private KeyboardControls keyboardControls;

    float jumpSpeed, gravity = 1;
    bool grounded, jumping;

    void Start()
    {
        // Build the controls desired by the user
        keyboardControls = KeyboardControls.Instance;

        if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.Arrows))
        {
            controlsBuilder = new ArrowControlsBuilder();
        }
        if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.WASD))
        {
            controlsBuilder = new WASDContolsBuilder();
        }

        builderDirector.Construct(controlsBuilder);

        controllerKeys = controlsBuilder.SetPlayerControls();

        // Instantiate concrete commands
        keyLeft = new TurnLeft();
        keyRight = new TurnRight();
        keyForward = new MoveForward();
        keyBack = new MoveBack();
        keyJump = new JumpUp();
        aCharacterController = this.gameObject.GetComponent<CharacterController>();
    }

    //Update is called once per frame
    void Update()
    {
        // If else calculates player gravity on the terrain
        grounded = aCharacterController.isGrounded;
        if (grounded)
        {
            jumping = false;
            jumpSpeed = 0;
        }
        else
            jumpSpeed -= (gravity * 1) * Time.deltaTime;
            aCharacterController.Move(new Vector3(0, 1, 0) * jumpSpeed);

        // Move left
        if (Input.GetKey(controllerKeys.ElementAt(0)))
        {
            keyForward.Execute(this.gameObject, aCharacterController);
        }

        // Move right
        if (Input.GetKey(controllerKeys.ElementAt(1)))
        {
            keyBack.Execute(this.gameObject, aCharacterController);
        }
        // Move forward
        if (Input.GetKey(controllerKeys.ElementAt(2)))
        {
            keyLeft.Execute(this.gameObject, aCharacterController);
        }

        // Move backward
        if (Input.GetKey(controllerKeys.ElementAt(3)))
        {
            keyRight.Execute(this.gameObject, aCharacterController);
        }

        //Jump movement; will jump the player up and down, not jump forward or backward
        if (Input.GetKeyUp(controllerKeys.ElementAt(4)))
        {
            keyJump.Execute(this.gameObject, aCharacterController);
        }
    }

}
