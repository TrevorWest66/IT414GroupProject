//Written by Lance Graham
//This is another model/controller responsible for coordinating the character's movement and location
using UnityEngine;

public class Navigator : MonoBehaviour
{
    private float hMove = 0.0f;
    private float vMove = 10.0f;
    private float speed = 3.0f;
    public  bool enableDisplay = false;

    private AbstractCalculate distanceCalculator = new ThreeDimensionalCalculate();

    //Update is called once per frame
    void Update()
    {
        //Could use a singleton to track the gameobjects and the cauldron
        Vector3 theCauldron = new Vector3(0, 0, 0);
        Vector3 currentLocation = this.GetComponent<Transform>().position;

        enableDisplay = distanceCalculator.Calculate(theCauldron, currentLocation);

        //Move Forward
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            vMove = 10.0f;
        }

        //Move Back
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            vMove = -10.0f;
        }

        //Turn Left
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }

        //Turn Right
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //transform is the game object
            transform.Rotate(0.0f, 90.0f, 0.0f);
        }

        Vector3 aMove = transform.forward * vMove + transform.right * hMove;
        this.GetComponent<CharacterController>().Move(aMove * Time.deltaTime * speed);
        hMove = 0.0f;
        vMove = 0.0f;
    }
}
