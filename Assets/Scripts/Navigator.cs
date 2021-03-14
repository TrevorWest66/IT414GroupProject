//Written by Lance Graham & Ellie McDonald
//This is another model/controller responsible for coordinating the character's movement and location
using UnityEngine;
using System.Threading.Tasks;

public class Navigator : MonoBehaviour
{
    private float hMove = 0.0f;
    private float vMove = 10.0f;
    private float speed = 3.0f;
    public  bool enableDisplay = false;

    private XmlParser anXmlParser;
    private KeyCode left, right, forward, backward, jump;

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

        //Parse the xml file to establish the controls that wil be used to move the capsule
        //through the maze. The Contrlols.xml file is located in the Maze SandBox directory.
        if (controls.GetType().ToString().Contains("ArrowControlsBuilder"))
        {
            anXmlParser = new XmlParser();
            anXmlParser.loadDocument(controls.SetPlayerControls());
            Debug.Log("Set player Controls: arrow");
        }
        else if (controls.GetType().ToString().Contains("WASDContolsBuilder"))
        {
            anXmlParser = new XmlParser();
            anXmlParser.loadDocument(controls.SetPlayerControls());
            Debug.Log("Set player Controls: wasd");
        }

        forward = anXmlParser.parseXml("forward");      // W or up arrow
        backward = anXmlParser.parseXml("backward");    //S or down arow
        left = anXmlParser.parseXml("left");            //A or left arrow
        right = anXmlParser.parseXml("right");          //D or right arrow
        jump = anXmlParser.parseXml("jump");            // Space bar
    }

    //Update is called once per frame
    void Update()
    {
        //Could use a singleton to track the gameobjects and the cauldron
        Vector3 theCauldron = new Vector3(0, 0, 0);
        Vector3 currentLocation = this.GetComponent<Transform>().position;

        enableDisplay = distanceCalculator.Calculate(theCauldron, currentLocation);

        //Move Forward
        if (Input.GetKeyUp(forward))
        {
            vMove = 10.0f;
        }

        //Move Back
        if (Input.GetKeyUp(backward))
        {
            vMove = -10.0f;
        }

        //Turn Left
        if (Input.GetKeyUp(left))
        {
            transform.Rotate(0.0f, -10.0f, 0.0f);
        }

        //Turn Right
        if (Input.GetKeyUp(right))
        {
            //transform is the game object
            transform.Rotate(0.0f, 10.0f, 0.0f);
        }

        // TODO: Do we want to implement this?
        // Jump
        /*if (Input.GetKeyUp(jump))
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
