﻿//Written by Lance Graham & Ellie McDonald
//This is another model/controller responsible for coordinating the character's movement and location
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class Navigator : MonoBehaviour
{
    public static bool enableDisplay = false;
    private AbstractCalculate distanceCalculator = new ThreeDimensionalCalculate();

    public List<KeyCode> controllerKeys;
    AbstractPlayerControllerCommand keyLeft, keyRight, keyForward, keyBack, keyJump;
    public CharacterController aCharacterController;

    // Dictates which controls will be used
    private BuilderDirector builderDirector = new BuilderDirector();
    private PlayerControlsBuilder controlsBuilder;
    private KeyboardControls keyboardControls;

    // Time will be used to determine if players keyboard control preferences have changes recently
    private DateTime timeControlsWereSetInNavigator;

    float jumpSpeed, gravity = 1;
    bool grounded, jumping;

    void Start()
    {
        keyboardControls = KeyboardControls.Instance;

        if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.Arrows))
        {
            controlsBuilder = new ArrowControlsBuilder();
        }
        if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.WASD))
        {
            controlsBuilder = new WASDContolsBuilder();
        }

        // This will help to program determine when the player controls preferences were updates in the options menu
        timeControlsWereSetInNavigator = keyboardControls.TimeControlsChanged;
        builderDirector.Construct(controlsBuilder);

        controllerKeys = controlsBuilder.SetPlayerControls();

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
        Vector3 theCauldron = new Vector3(0, 0, 0);
        Vector3 currentLocation = this.GetComponent<Transform>().position;

        enableDisplay = distanceCalculator.Calculate(theCauldron, currentLocation);

        grounded = aCharacterController.isGrounded;

        Debug.Log(grounded);
        if (grounded)
        {
            jumping = false;
            jumpSpeed = 0;
        }
        else
            jumpSpeed -= (gravity * 25) * Time.deltaTime;
            aCharacterController.Move(new Vector3(0, 1, 0) * jumpSpeed);

        if (Input.GetKey(controllerKeys.ElementAt(0)))
        {
            Debug.Log("movement commands getting sent");
            keyForward.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKey(controllerKeys.ElementAt(1)))
        {
            keyBack.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKey(controllerKeys.ElementAt(2)))
        {
            keyLeft.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKey(controllerKeys.ElementAt(3)))
        {
            keyRight.Execute(this.gameObject, aCharacterController);
        }

        //Currently we do not save the jump commands in the stack as the jump movement is only meant to
        //to jump the player up and down, not jump forward or backward
        if (Input.GetKeyUp(controllerKeys.ElementAt(4)))
        {
            keyJump.Execute(this.gameObject, aCharacterController);
        }
    }

    // TODO: Used fixed update to change player controls midgame if they've been updates in the options menu
    /*void FixedUpdate()
    {
        if (keyboardControls.TimeControlsChanged != timeControlsWereSetInNavigator)
        {
            if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.Arrows))
            {
                controlsBuilder = new ArrowControlsBuilder();
            }
            if (keyboardControls.ControlType.Equals(KeyboardControlsEnum.WASD))
            {
                controlsBuilder = new WASDContolsBuilder();
            }
            timeControlsWereSetInNavigator = keyboardControls.TimeControlsChanged;
            builderDirector.Construct(controlsBuilder);
            controllerKeys = controlsBuilder.SetPlayerControls();
            Debug.Log("Set player Controls: " + controlsBuilder.GetType().ToString());
            keyLeft = new TurnLeft();
            keyRight = new TurnRight();
            keyForward = new MoveForward();
            keyBack = new MoveBack();
            keyJump = new JumpUp();
            aCharacterController = this.gameObject.GetComponent<CharacterController>();
        }
        
    }*/

}
