// Author: Ellie McDonald
// 04/04/21
// This class allows the user to peek at their inventory during the main game

using UnityEngine;

public class PeekPlayerInventory : MonoBehaviour
{
    // Inventory variables
    public static bool inventoryDisplayed = false;
    private Canvas inventoryCanvas, recipeCanvas, craftingCanvas;
    private Inventory theInventory;

    private GameObject playMiniGameButton, backButton, potionRecipeButton;

    // Player Variables
    public GameObject player;
    public GameObject cam;

    void Start()
    {
        // Get the inventory canvas, play mini game button and back button
        inventoryCanvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        recipeCanvas = GameObject.Find("PotionRecipeCanvas").GetComponent<Canvas>();
        craftingCanvas = GameObject.Find("CraftingCanvas").GetComponent<Canvas>();

        playMiniGameButton = GameObject.Find("Play Mini Game Button");
        potionRecipeButton = GameObject.Find("RecipeButton");
        inventoryBackButton = GameObject.Find("Back To Game Button");

        theInventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryDisplayed)
            {
                Resume();
            }
            // Only peek at the inventory when not near the cauldron or not having collected any plants
            else if (!(inventoryCanvas.enabled || recipeCanvas.enabled || craftingCanvas.enabled))
            {
                ShowInventory();
            }
        }
    }

    public void Resume()
    {
        // Disable inventory canvas
        inventoryCanvas.enabled = false;
        Time.timeScale = 1f;
        inventoryDisplayed = false;
        // Re-enable inventory canvas button
        playMiniGameButton.SetActive(true);
        inventoryBackButton.SetActive(true);
        potionRecipeButton.SetActive(true);

        // Enable player movements 
        cam.GetComponent<MouseLook>().enabled = true;
        player.GetComponent<Navigator>().enabled = true;

    }

    public void ShowInventory()
    {
        //Populate inventory
        theInventory.PopulateInventory();

        // Enable Inventory canvas
        inventoryCanvas.enabled = true;
        inventoryDisplayed = true;

        // Disable inventory canvas button
        playMiniGameButton.SetActive(false);
        inventoryBackButton.SetActive(false);
        potionRecipeButton.SetActive(false);

        // Disable player movements
        cam.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<Navigator>().enabled = false;

    }
}
