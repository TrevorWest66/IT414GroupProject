using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDisplay : MonoBehaviour
{
    private GameObject craftingButton;

    //Start is called before the first frame udpate
    void Start()
    {
        craftingButton = GameObject.Find("CraftingButton");
        craftingButton.SetActive(false);
    }

    void OnGUI()
    {
        bool showButton = Navigator.enableDisplay;

        if (showButton)
        {
            // Unlocks the mouse so that the player is able to interact with the button
            Cursor.lockState = CursorLockMode.None;
            craftingButton.SetActive(true);
        }

        else
        {
            // Locks the mouse after the player leaves to couldron
            Cursor.lockState = CursorLockMode.Locked;
            craftingButton.SetActive(false);
        }
    }
}
