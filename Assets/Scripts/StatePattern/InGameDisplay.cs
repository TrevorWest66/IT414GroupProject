//Written by Lance Graham
//This is the in game display class responsible for displaying buttons and canvas' that the player
//can interact with during the game. These are "in game" displays that won't stop or halt the game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDisplay : MonoBehaviour
{
    private State state;
    private Canvas craftingCanvas, inventoryCanvas;
    private Button craftingButton, backButton;

    private bool enableCraftingCanvas, enableInventoryCanvas;

    //Getter and setter for the state that the ingamedisplay object is in
    public State State
    {
        get { return this.state; }
        set { this.state = value; }
    }

    //Gather plants according to the state that the player is in
    public void GatherPlant()
    {
        Dictionary<string, bool> displayOptions = state.GatherPlant(this);
        SetDisplayOptions(displayOptions);
    }

    //Ability to see crafting button according to the state that the player is in
    public void ChooseCraft()
    {
        Dictionary<string, bool> displayOptions = state.ChooseCraft(this);
        SetDisplayOptions(displayOptions);
    }

    //Ability to see the inventory w/ mini game options according to state that the player is in
    public void ChooseInventory()
    {
        Dictionary<string, bool> displayOptions = state.ChooseInventory(this);
        SetDisplayOptions(displayOptions);
    }

    //Method tied to the Back button on the inventory canvas
    //When it is clicked we need to disable the inventory canvas
    public void Back()
    {
        //Will return the player to the crafting state since this button can only be invoked from the inventory state
        ChooseCraft();
    }

    //Parse the dictionary to determine which canvas' to enable (I.E. the crafting button vs. inventory canvas with mini game options).
    public void SetDisplayOptions(Dictionary<string, bool> displayOptions)
    {
        bool canvasState;
        displayOptions.TryGetValue("craftingDisplay", out canvasState);
        enableCraftingCanvas = canvasState;

        displayOptions.TryGetValue("inventoryDisplay", out canvasState);
        enableInventoryCanvas = canvasState;
    }

    void Start()
    {
        //Get and set the instance variables upon start of game
        craftingCanvas = GameObject.Find("CraftingCanvas").GetComponent<Canvas>();
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();

        craftingButton = GameObject.Find("CraftingButton").GetComponent<Button>();
        backButton = GameObject.Find("Back To Game Button").GetComponent<Button>();

        //Add event listeners needed for when the player can click the crafting button and back button depending on the state.
        craftingButton.onClick.AddListener(delegate () { ChooseInventory(); });
        backButton.onClick.AddListener(delegate () { ChooseCraft(); });

        //Add the different states that a player can be in to the player gameobject
        this.gameObject.AddComponent<NoPlantState>();
        this.gameObject.AddComponent<CraftingState>();
        this.gameObject.AddComponent<InventoryState>();

        //At start of game the player is in the no plant state since
        State = this.gameObject.GetComponent<NoPlantState>();
    }

    //Unity function responsible for handling GUI events
    //The player will switch states according to the logic below (distance with cauldron, number of plants selected, and player input when selecting buttons)
    void OnGUI()
    {
        //First conditional checks to make sure that the user doesn't have the regular inventory canvas open.
        //The regular inventory canvas doesn't have back button or play mini game button
        if (!PeekPlayerInventory.inventoryDisplayed)
        {
            //The distance between the player and the cauldron
            bool showCraftingButton = Navigator.enableDisplay;

            //Player is in the no plant state, but has collected a plant and has gone to the cauldron so the player will switch to crafting state
            if (CurrentGameObjects.Instance.CountObjectsCollected() > 0 && showCraftingButton && state.GetType().Name == "NoPlantState")
            {
                GatherPlant();
            }
            
            //Player is in inventory state and is at cauldron meaning the inventory with mini game options will be displayed
            else if (state.GetType().Name == "InventoryState" && showCraftingButton)
            {
                ChooseInventory();
            }

            //Else the player can be in the inventory state and collect plants without any canvas displayed
            else if (state.GetType().Name == "InventoryState")
            {
                GatherPlant();
            }

            //Else the player is in crafting state and is at cauldron meaning the crafting button must be displayed
            else if (state.GetType().Name == "CraftingState" && showCraftingButton)
            {
                ChooseCraft();
            }

            //Else the player is not at cauldron and can collect plants without the canvas displayed
            else if (state.GetType().Name == "CraftingState")
            {
                GatherPlant();
            }

            //Separate if else block actually enables the canvas' on the GUI
            if (enableInventoryCanvas || enableCraftingCanvas)
            {
                //Unlock player cursor since one of the canvas' is going to be displayed which requires user interaction
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                //Lock player cursor since both canvas' are disabled
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            //Enables the canvas' on the GUI depending on state
            craftingCanvas.enabled = enableCraftingCanvas;
            inventoryCanvas.enabled = enableInventoryCanvas;
        }
    }
}
