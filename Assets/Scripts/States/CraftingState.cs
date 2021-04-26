// Written by Lance Graham
// 04/10/2021
// This is the crafting state where a player now has the ability to see the crafting button when he or she approaches the cauldron. 
// The player has collected at least one plant to be in this state.

using System.Collections.Generic;
using UnityEngine;

public class CraftingState : MonoBehaviour, State
{
    private Dictionary<string, bool> canvasCriteria = new Dictionary<string, bool>();

    public Dictionary<string, bool> GatherPlant(InGameDisplay context)
    {
        // The player can continue gathering plants, but we don't display any canvas and there's no need to change
        // states since the player is only collecting plants. 
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseCraft(InGameDisplay context)
    {
        // The crafting canvas is enabled in this state since the player has collected at least one plant
        canvasCriteria["craftingDisplay"] = true;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseInventory(InGameDisplay context)
    {
        // If the player clicks the crafting button we disable both canvas' and switch to inventory state
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;
        context.State = this.gameObject.GetComponent<InventoryState>();

        return canvasCriteria;
    }

    public Dictionary<string, bool> ViewRecipe(InGameDisplay context)
    {
        // Cannot view recipe from crafting state
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }
}
