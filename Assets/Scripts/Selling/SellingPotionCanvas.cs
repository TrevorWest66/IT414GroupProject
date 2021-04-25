﻿// Ellie McDonald
// 04/23/2021
// This class controls the Potion Selling Canvas

using System.Collections.Generic;
using UnityEngine;
public class SellingPotionCanvas : MonoBehaviour
{
    private Canvas sellingPrompt, potionInventoryCanvas;
    private PotionInventory potionInventory = new PotionInventory();

    private bool repopulateInventory = true;

    private Potion currentPotionSelection = null;
    private int currentSlotSelection = 0;
    void Start()
    {
        sellingPrompt = GameObject.Find("SellPotionCanvas").GetComponent<Canvas>();
        potionInventoryCanvas = GameObject.Find("PotionInventoryCanvas").GetComponent<Canvas>();
    }
    void OnGUI()
    {
        if (repopulateInventory)
        {
            potionInventory.PopulateInventory();
            repopulateInventory = false;
        }
    }

    public void ClickBack()
    {
        repopulateInventory = true;
        sellingPrompt.enabled = true;
        potionInventoryCanvas.enabled = false;

        // Remove current selections
        currentSlotSelection = 0;
        currentPotionSelection = null;
    }

    public void ClickSell()
    {
        if (!(currentPotionSelection == null))
        {
            // TODO: Call method in coin class that will increase the players coin
            int coinValue = currentPotionSelection.PotionCoinValue;

            // Set to null, the current selected was sold
            currentPotionSelection = null;

            CurrentGameObjects.Instance.removePotion(currentPotionSelection);
        }
    }

    public void ClickSlot(int slotNumber)
    {
        if ((currentSlotSelection != 0) && (currentSlotSelection != slotNumber))
        {
            potionInventory.UnhighlightSlot(currentSlotSelection);
        }
        potionInventory.HighlightSlot(slotNumber);
        Dictionary<int, Potion> slotPotionDictionary = potionInventory.SlotPotionDictionary;
        slotPotionDictionary.TryGetValue(slotNumber, out currentPotionSelection);
        currentSlotSelection = slotNumber;
    }
}