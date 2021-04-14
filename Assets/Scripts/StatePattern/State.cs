//Written by Lance Graham
// 4/10/2021
//This is the interface used for the state pattern.
//There are three states: no plant, crafting, and an inventory state.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    Dictionary<string, bool> GatherPlant(InGameDisplay context);
    Dictionary<string, bool> ChooseCraft(InGameDisplay context);
    Dictionary<string, bool> ViewRecipe(InGameDisplay context);
    Dictionary<string, bool> ChooseInventory(InGameDisplay context);
}
