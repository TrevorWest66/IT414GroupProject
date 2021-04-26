// Written by Ellie McDonald
// 04/12/21
// This class displays the potion recipes on the potion recipe canvas

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionRecipeListDisplay : MonoBehaviour
{
    public GameObject recipeTextBox;
    private AbstractIterator iterator;

    private Canvas inventoryCanvas, potionRecipeCanvas, craftingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        potionRecipeCanvas = GameObject.Find("PotionRecipeCanvas").GetComponent<Canvas>();
        craftingCanvas = GameObject.Find("CraftingCanvas").GetComponent<Canvas>();

        Text myText = recipeTextBox.AddComponent<Text>();
        myText.font = (Font)Resources.Load("Fonts/JazzCreateBubble");
        myText.fontSize = 35;
        myText.color = Color.white;
        myText.alignment = TextAnchor.MiddleCenter;

        myText.text = PopulatePotionRecipe();
    }
    
    // Method will return a string containing the recipe
    public string PopulatePotionRecipe()
    {
        string recipe = "";
        iterator = new PotionRecipeIterator();

        while (iterator.hasNext())
        {
            Potion aPotion = (Potion)iterator.next();

            string potionName = aPotion.PotionName;
            recipe += potionName + " = ";

            List<CollectablePlantsEnum> plantsInPotion = aPotion.PlantsInPotion;

            int plantCount = 1;
            foreach (CollectablePlantsEnum plant in plantsInPotion)
            {
                if (plantCount < plantsInPotion.Count)
                {
                    recipe += plant.GetDescription() + " + ";
                }
                else
                {
                    recipe += plant.GetDescription();
                }

                plantCount++;
            }
            recipe += "\n";
        }
        return recipe;
    }
}
