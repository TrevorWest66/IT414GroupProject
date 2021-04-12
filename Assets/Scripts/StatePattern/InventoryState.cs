//Written by Lance Graham
// 4/10/2021
//This is the third state where the player sees the inventory canvas with the ability to select "Back" or "Play Mini Game". 
//The player must go to the cauldron to see these options.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : MonoBehaviour, State
{
    private Dictionary<string, bool> canvasCriteria = new Dictionary<string, bool>();
    public Dictionary<string, bool> GatherPlant(InGameDisplay context)
    {
        ////The player can continue gathering plants, but we don't display any canvas and there's no need to change
        //states since the player is only collecting plants. 
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseCraft(InGameDisplay context)
    {
        //The canvas' are disabled because the player should not be able to see the crafting canvas while in the inventory state.
        //If this method is invoked we switch to the crafting state where the player will have the ability to see the crafting button,
        //but won't be able to see the inventory canvas with the mini game options. 
        context.State = this.gameObject.GetComponent<CraftingState>();
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseInventory(InGameDisplay context)
    {
        //Since we are in the inventory state, we must populate the inventory and enable the canvas if this method is invoked.
        //This will allow the user to see the inventory canvas and select "Back" or "Play Mini Game". 
        Inventory theInventory = new Inventory();
        theInventory.PopulateInventory();

        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = true;

        return canvasCriteria;
    }
}
