// Written by Ellie McDonald
// 4/13/21

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
        // user is still viewing the recipes
        canvasCriteria["craftingDisplay"] = false;
        canvasCriteria["inventoryDisplay"] = false;
        canvasCriteria["recipeDisplay"] = true;

        return canvasCriteria;
    }
}

