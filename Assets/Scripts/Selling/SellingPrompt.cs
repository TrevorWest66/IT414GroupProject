// Written by Ellie McDonald
// 04/22/21 
// This class will control when the selling canvas are enabled 
using UnityEngine;

public class SellingPrompt : MonoBehaviour
{
    private Vector3 player, sellingShed;
    private Canvas sellPotionCanvas, potionInventoryCanvas;

    private bool enablePrompt = false;
    private AbstractCalculate distance = new ThreeDimensionalCalculateSellingShed();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Male A").transform.position;
        sellingShed = GameObject.Find("Selling Shed").transform.position;
        sellPotionCanvas = GameObject.Find("SellPotionCanvas").GetComponent<Canvas>();
        potionInventoryCanvas = GameObject.Find("PotionInventoryCanvas").GetComponent<Canvas>();
    }

    void OnGUI()
    {
        player = GameObject.Find("Male A").transform.position;

        enablePrompt = distance.Calculate(player, sellingShed);

        // If the player is close enough and the potion inventory cavas is not displayed
        if (enablePrompt && (!potionInventoryCanvas.enabled))
        {
            UnlockCursor();
            sellPotionCanvas.enabled = true;
        }
        // If the player is not close enough to the shed and the and the potion inventory canvas is displayed
        else if ((!enablePrompt) && (potionInventoryCanvas.enabled))
        {
            sellPotionCanvas.enabled = false;
            potionInventoryCanvas.enabled = false;
        }
        // If the player is not close enough and potion inventory is not displayed
        else
        {
            sellPotionCanvas.enabled = false;
        }

    }

    private void UnlockCursor()
    {
        //Unlock player cursor since one of the canvas' is going to be displayed which requires user interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ClickSellMyPotions()
    {
        // Disable to sell potion button
        sellPotionCanvas.enabled = false;
        enablePrompt = false;

        // Enable to Inventory Canvas
        potionInventoryCanvas.enabled = true;
    }
}
