using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenuSetControls : MonoBehaviour
{
    public bool isArrows = true;

    public void OnClickLeft()
    {
        if (isArrows)
        {
            Debug.Log("Set controls for WASD");
            isArrows = false;
        } 

        else if (! isArrows)
        {
            Debug.Log("Set controls for Arrows");
            isArrows = true;
        }

        transform.Rotate(Vector3.forward * 10);

    }

    private void setControlsInConfigFile()
    {

    }
}
