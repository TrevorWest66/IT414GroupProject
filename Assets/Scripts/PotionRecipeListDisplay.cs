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

    private Canvas inventoryCanvas;
    private Canvas potionRecipeCanvas;

    // Start is called before the first frame update
    void Start()
    {
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        potionRecipeCanvas = GameObject.Find("PotionRecipeCanvas").GetComponent<Canvas>();

        Text myText = recipeTextBox.AddComponent<Text>();
        myText.font = (Font)Resources.Load("Fonts/JazzCreateBubble");
        myText.fontSize = 35;
        myText.color = Color.white;
        myText.alignment = TextAnchor.MiddleCenter;
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

        myText.text = recipe;
    }

    public void ClickBack()
    {
        //The back button has not been clicked yet as the inventory canvas hasn't been displayed so we set this static variable to false
        InGameDisplay.backClicked = false;

        inventoryCanvas.enabled = true;
        potionRecipeCanvas.enabled = false;
    }
}
