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
        PlayerControlsBuilder controls;
        if (true)
        {
            controls = new ArrowControlsBuilder();
        }
        if (false /*change to pull in settings from main menu settings*/)
        {
            controls = new WASDContolsBuilder();
        }

        builderDirector.Construct(controls);

        controllerKeys = controls.SetPlayerControls();
        Debug.Log("Set player Controls: " + controls.GetType().ToString());

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

        if (Input.GetKeyDown(controllerKeys.ElementAt(0)))
        {
            keyForward.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKeyDown(controllerKeys.ElementAt(1)))
        {
            keyBack.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKeyDown(controllerKeys.ElementAt(2)))
        {
            keyLeft.Execute(this.gameObject, aCharacterController);
        }

        if (Input.GetKeyDown(controllerKeys.ElementAt(3)))
        {
            keyRight.Execute(this.gameObject, aCharacterController);
        }

        //This is a newly added jump feature by Ellie
        //Currently we do not save the jump commands in the stack as the jump movement is only meant to
        //to jump the player up and down, not jump forward or backward
        if (Input.GetKeyUp(controllerKeys.ElementAt(4)))
        {
            keyJump.Execute(this.gameObject, aCharacterController);
        }
    }
}
