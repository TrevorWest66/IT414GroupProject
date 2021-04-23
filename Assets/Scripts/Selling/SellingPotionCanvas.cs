// Ellie McDonald
// 04/23/2021
// This class controls the Potion Selling Canvas

using UnityEngine;
class SellingPotionCanvas : MonoBehaviour
{
    private Canvas sellingPrompt, potionInventoryCanvas;
    void Start()
    {
        sellingPrompt = GameObject.Find("SellPotionCanvas").GetComponent<Canvas>();
        potionInventoryCanvas = GameObject.Find("PotionInventoryCanvas").GetComponent<Canvas>();
    }
    void OnGUI()
    {

    }

    public void ClickBack()
    {
        sellingPrompt.enabled = true;
        potionInventoryCanvas.enabled = false;
    }

    public void ClickSell()
    {
        // TODO: get selected object, sell it
    }
}
