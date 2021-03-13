//Written by Lance Graham
//This is a view that is responsible for displaying the interactive buttons and menus to the screen for the user
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicalUserInterfaceDisplay : MonoBehaviour
{
    private Rect craftingButton = new Rect(Screen.width / 2, Screen.height / 2, 100, 45);
    void OnGUI()
    {
        bool showButton = this.GetComponent<Navigator>().enableDisplay;

        if (showButton)
        {
            if (GUI.Button(craftingButton, "Craft Potions"))
            {
                //Strategy pattern to load mini game?
                Debug.Log("BUTTON CLICKED");
            }
        }
    }
}
