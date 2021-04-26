// Written by Lance Graham and Ellie McDonald
// 04/10/2021
// This is the in game display class responsible for displaying buttons and canvas' that the player
// can interact with during the game. These are "in game" displays that won't stop or halt the game.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameDisplay : MonoBehaviour
{
    private GameObject thePlayer;
    private AbstractCalculate distanceCalculatorCrafting = new ThreeDimensionalCalculateCrafting();
    private Vector3 currentLocation, theCauldron;

    private State state;
    private Canvas craftingCanvas, inventoryCanvas, potionRecipeCanvas, sellPotionCanvas, potionInventoryCanvas;
    private Button craftingButton, inventoryBackButton, potionRecipeButton, recipeBackButton;

    private bool enableCraftingCanvas, enableInventoryCanvas, enableRecipeCanvas;

    // Getter and setter for the state that the ingamedisplay object is in
    public State State
    {
        get { return this.state; }
        set { this.state = value; }
    }

    // Gather plants according to the state that the player is in
    public void GatherPlant()
    {
        Dictionary<string, bool> displayOptions = state.GatherPlant(this);
        SetDisplayOptions(displayOptions);
    }

    // Ability to see crafting button according to the state that the player is in
    public void ChooseCraft()
    {
        Dictionary<string, bool> displayOptions = state.ChooseCraft(this);
        SetDisplayOptions(displayOptions);
    }

    // Ability to see the inventory w/ mini game options according to state that the player is in
    public void ChooseInventory()
    {
        Dictionary<string, bool> displayOptions = state.ChooseInventory(this);
        SetDisplayOptions(displayOptions);
    }

    public void ViewRecipeList()
    {
        Dictionary<string, bool> displayOptions = state.ViewRecipe(this);
        SetDisplayOptions(displayOptions);
    }

    // Method tied to the Back button on the inventory canvas
    // When it is clicked we need to disable the inventory canvas
    public void Back()
    {
        // Will return the player to the crafting state since this button can only be invoked from the inventory state
        ChooseCraft();
    }

    // Parse the dictionary to determine which canvas' to enable (I.E. the crafting button vs. inventory canvas with mini game options).
    public void SetDisplayOptions(Dictionary<string, bool> displayOptions)
    {
        bool canvasState;
        displayOptions.TryGetValue("craftingDisplay", out canvasState);
        enableCraftingCanvas = canvasState;

        displayOptions.TryGetValue("inventoryDisplay", out canvasState);
        enableInventoryCanvas = canvasState;

        displayOptions.TryGetValue("recipeDisplay", out canvasState);
        enableRecipeCanvas = canvasState;
    }

    void Start()
    {
        // The player game object
        thePlayer = GameObject.Find("Male A");
        // Location of cauldron
        theCauldron = new Vector3(0, 0, 0);

        // Get and set the instance variables upon start of game
        craftingCanvas = GameObject.Find("CraftingCanvas").GetComponent<Canvas>();
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        potionRecipeCanvas = GameObject.Find("PotionRecipeCanvas").GetComponent<Canvas>();
        sellPotionCanvas = GameObject.Find("SellPotionCanvas").GetComponent<Canvas>();
        potionInventoryCanvas = GameObject.Find("PotionInventoryCanvas").GetComponent<Canvas>();

        craftingButton = GameObject.Find("CraftingButton").GetComponent<Button>();
        inventoryBackButton = GameObject.Find("Back To Game Button").GetComponent<Button>();
        potionRecipeButton = GameObject.Find("RecipeButton").GetComponent<Button>();
        recipeBackButton = GameObject.Find("Potion Recipe Back").GetComponent<Button>();

        // Add event listeners needed for when the player can click the crafting button and back button depending on the state.
        craftingButton.onClick.AddListener(delegate () { ChooseInventory(); });
        inventoryBackButton.onClick.AddListener(delegate () { ChooseCraft(); });
        potionRecipeButton.onClick.AddListener(delegate () { ViewRecipeList(); });
        recipeBackButton.onClick.AddListener(delegate () { ChooseInventory(); });

        // Add the different states that a player can be in to the player gameobject
        this.gameObject.AddComponent<NoPlantState>();
        this.gameObject.AddComponent<CraftingState>();
        this.gameObject.AddComponent<InventoryState>();
        this.gameObject.AddComponent<ViewRecipeListState>();

        // At start of game the player is in the no plant state
        State = this.gameObject.GetComponent<NoPlantState>();
    }

    // Unity function responsible for handling GUI events
    // The player will switch states according to the logic below (distance with cauldron, number of plants selected, and player input when selecting buttons)
    void OnGUI()
    {
        // The player's current location on map
        currentLocation = thePlayer.transform.position;

        // First conditional checks to make sure that the user doesn't have the regular inventory canvas open.
        // The regular inventory canvas doesn't have back button or play mini game button
        if (!PeekPlayerInventory.inventoryDisplayed)
        {
            // The distance between the player and the cauldron
            bool showCraftingButton = distanceCalculatorCrafting.Calculate(theCauldron, currentLocation);


            // Player is in the no plant state, but has collected a plant and has gone to the cauldron so the player will switch to crafting state
            if (CurrentGameObjects.Instance.CountObjectsCollected() > 0 && showCraftingButton && state.GetType().Name == "NoPlantState")
            {
                GatherPlant();
            }
            
            // Player is in inventory state and is at cauldron meaning the inventory with mini game options will be displayed
            else if (state.GetType().Name == "InventoryState" && showCraftingButton)
            {
                ChooseInventory();
            }

            // Else the player can be in the inventory state and collect plants without any canvas displayed
            else if (state.GetType().Name == "InventoryState")
            {
                GatherPlant();
            }

            // Else the player is in crafting state and is at cauldron meaning the crafting button must be displayed
            else if (state.GetType().Name == "CraftingState" && showCraftingButton)
            {
                ChooseCraft();
            }

            // Else the player is not at cauldron and can collect plants without the canvas displayed
            else if (state.GetType().Name == "CraftingState")
            {
                GatherPlant();
            }

            // Else the player is at cauldron and viewing the recipe screen
            else if (state.GetType().Name == "ViewRecipeListState" && showCraftingButton)
            {
                ViewRecipeList();
            }

            // Else the player is not at cauldron and can collect plants without the canvas displayed
            else if (state.GetType().Name == "ViewRecipeListState")
            {
                GatherPlant();
            }

            // Separate if else block actually enables the canvas' on the GUI
            if (enableInventoryCanvas || enableCraftingCanvas || enableRecipeCanvas || sellPotionCanvas.enabled || potionInventoryCanvas.enabled)
            {

                UnlockCursor();
            }
            else
            {
                LockCursor();
            }

            // Enables the canvas' on the GUI depending on state
            craftingCanvas.enabled = enableCraftingCanvas;
            inventoryCanvas.enabled = enableInventoryCanvas;
            potionRecipeCanvas.enabled = enableRecipeCanvas;
        }
    }

    // Unlock player cursor since one of the canvas' is going to be displayed which requires user interaction
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Lock player cursor since both canvas' are disabled
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
