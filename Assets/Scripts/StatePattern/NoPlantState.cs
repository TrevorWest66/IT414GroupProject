//Written by Lance Graham
// 4/10/2021
//This is the first state that the player automatically starts out in. The player can not craft plants or play mini games in this state
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPlantState : MonoBehaviour, State
{
    //Dictionary holds the booleans for displaying the crafting and inventory canvas
    private Dictionary<string, bool> canvasCriteria = new Dictionary<string, bool>();

    //I should use an enum for the canvas names
    public Dictionary<string, bool> GatherPlant(InGameDisplay context)
    {
        //No canvas' should be displayed in this state
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        //If the player picks up a plant, the player moves into the crafting state where he or she can now see the crafting canvas
        //when approaching the cauldron
        context.State = this.gameObject.GetComponent<CraftingState>();
        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseCraft(InGameDisplay context)
    {
        //No canvas' should be displayed in this state; the player does not have the ability to craft since they have not collected plants
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseInventory(InGameDisplay context)
    {
        //No canvas' should be displayed in this state; the player does not have the ability to play mini games until they collect a plant,
        //click the crafting button, and select 'Play Mini Game'
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ViewRecipe(InGameDisplay context)
    {
        // can't view recipes without first collecting a plant and viewing the inventory
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }
}
