//Written by Lance Graham
//This is the in game display class responsible for displaying buttons and canvas' that the player
//can interact with during the game. These are "in game" displays that won't stop or halt the game
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameDisplay : MonoBehaviour
{
    private Canvas craftingCanvas;
    private Canvas inventoryCanvas;
    
    //Used for determing whether to display the crafting button or inventory canvas
    public static bool craftingClicked = false;
    public static bool backClicked = false;

    void Start()
    {
        //Get and set the craftingCanvas and inventoryCanvas instance variables upon start of game
        craftingCanvas = GameObject.Find("CraftingCanvas").GetComponent<Canvas>();
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
    }

    //Unity function responsible for handling GUI events
    void OnGUI()
    {
        //The distance between the player and the cauldron
        bool showCraftingButton = Navigator.enableDisplay;

        //Show the crafting button if the player is within distance of cauldron and the
        //crafting button hasn't been clicked (prevents overlay of crafting button with inventory canvas)
        if (showCraftingButton && !craftingClicked)
        {
            // Unlocks the mouse so that the player is able to interact with the button
            Cursor.lockState = CursorLockMode.None;

            craftingCanvas.enabled = true;
        }
        //If above conditions are false, don't display crafting button
        else
        {
            // Locks the mouse after the player leaves to couldron
            Cursor.lockState = CursorLockMode.Locked;

            craftingCanvas.enabled = false;
        }

        //If crafting button is clicked, display the inventory canvas
        if (craftingClicked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inventoryCanvas.enabled = true;

        }

        //If back button is clicked on the inventory canvas, disable the inventory canvas
        if (backClicked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            inventoryCanvas.enabled = false;
        }
    }

    //Method tied to the Back button on the inventory canvas
    //When it is clicked we need to disable the inventory canvas
    public void Back()
    {
        Cursor.lockState = CursorLockMode.Locked;
        backClicked = true;
        craftingClicked = false;
    }
}
