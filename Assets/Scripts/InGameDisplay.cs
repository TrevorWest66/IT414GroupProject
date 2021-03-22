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
            craftingButton.SetActive(true);
        }

        else
        {
            craftingButton.SetActive(false);
        }
    }
}
