//Written by Lance Graham & Ellie McDonald
//This is another model/controller responsible for coordinating the character's movement and location
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class Navigator : MonoBehaviour
{
    public  bool enableDisplay = false;
    public List<KeyCode> controllerKeys;

    AbstractPlayerControllerCommand keyLeft, keyRight, keyForward, keyBack, keyJump;
    public CharacterController aCharacterController;


    private AbstractCalculate distanceCalculator = new ThreeDimensionalCalculate();

    void Start()
    {
        // Dictates which controls will be used
        BuilderDirector builderDirector = new BuilderDirector();
        PlayerControlsBuilder controlsBuilder;
        KeyboardControls keyboardControls = new KeyboardControls();

        // TODO: should remove else and convert second if to else?
        if (keyboardControls.ControlIsArrows)
        {
            controlsBuilder = new ArrowControlsBuilder();
        }
        if (!(keyboardControls.ControlIsArrows))
        {
            controlsBuilder = new WASDContolsBuilder();
        }
        else // if any issues with code above set default
        {
            controlsBuilder = new ArrowControlsBuilder();
        }

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

    //Update is called once per frame
    void Update()
    {
        //Could use a singleton to track the gameobjects and the cauldron
        Vector3 theCauldron = new Vector3(0, 0, 0);
        Vector3 currentLocation = this.GetComponent<Transform>().position;

        enableDisplay = distanceCalculator.Calculate(theCauldron, currentLocation);

        if (Input.GetKey(controllerKeys.ElementAt(0))) // Up arrow or w
        {
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
}
