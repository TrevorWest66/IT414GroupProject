// Written by Ellie McDonald
// 04/13/21
// This is the view recipe state where the user has the ability to see the list of ingredients for a potion

using System.Collections.Generic;
using UnityEngine;

public class ViewRecipeListState : MonoBehaviour, State
{
    private Dictionary<string, bool> canvasCriteria = new Dictionary<string, bool>();
    public Dictionary<string, bool> ChooseCraft(InGameDisplay context)
    {
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ChooseInventory(InGameDisplay context)
    {
        context.State = this.gameObject.GetComponent<InventoryState>();
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> GatherPlant(InGameDisplay context)
    {
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = false;

        return canvasCriteria;
    }

    public Dictionary<string, bool> ViewRecipe(InGameDisplay context)
    {
        // User is still viewing the recipes
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = true;

        return canvasCriteria;
    }
}

