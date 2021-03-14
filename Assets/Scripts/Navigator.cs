//Written by Lance Graham & Ellie McDonald
//This is another model/controller responsible for coordinating the character's movement and location
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class Navigator : MonoBehaviour
{
    private float hMove = 0.0f;
    private float vMove = 10.0f;
    private float speed = 3.0f;
    public  bool enableDisplay = false;
    public List<KeyCode> controllerKeys;


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
        
    }

    //Update is called once per frame
    void Update()
    {
        //Could use a singleton to track the gameobjects and the cauldron
        Vector3 theCauldron = new Vector3(0, 0, 0);
        Vector3 currentLocation = this.GetComponent<Transform>().position;

        enableDisplay = distanceCalculator.Calculate(theCauldron, currentLocation);

        //Move Forward
        if (Input.GetKeyUp(controllerKeys.ElementAt(0))) // forward
        {
            vMove = 10.0f;
        }

        //Move Back
        if (Input.GetKeyUp(controllerKeys.ElementAt(1)))
        {
            vMove = -10.0f;
        }

        //Turn Left
        if (Input.GetKeyUp(controllerKeys.ElementAt(2)))
        {
            transform.Rotate(0.0f, -10.0f, 0.0f);
        }

        //Turn Right
        if (Input.GetKeyUp(controllerKeys.ElementAt(3)))
        {
            //transform is the game object
            transform.Rotate(0.0f, 10.0f, 0.0f);
        }

        // TODO: Do we want to implement this?
        // Jump
        /*if (Input.GetKeyUp(controllerKeys.ElementAt(4)))
        {
            float yMove = 13.0f;

            transform.position = new Vector3(transform.position.x, transform.position.y + yMove, transform.position.z);
            async Task.Delay(System.TimeSpan.FromSeconds(wait));
            transform.position = new Vector3(transform.position.x, transform.position.y + (0 - yMove), transform.position.z);
        }*/

        Vector3 aMove = transform.forward * vMove + transform.right * hMove;
        this.GetComponent<CharacterController>().Move(aMove * Time.deltaTime * speed);
        hMove = 0.0f;
        vMove = 0.0f;
    }
}
