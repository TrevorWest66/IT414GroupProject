// Ellie McDonald
// 04/23/2021
// This class controls populating the potion inventory for selling
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionInventory
{
    private GameObject theGameObject;
    private List<Potion> potionsCreated = new List<Potion>();
    private Dictionary<int, Potion> slotPotionDictionary = null;
    private int slot = 1;

    private Color unselectedSlotColor = new Color(0.4f, 0.4f, 0.4f, 0.9f);
    private Color highlightSlotColor = new Color(1f, 1f, 1f, 1f);

    public void PopulateInventory()
    {
        Reset();

        potionsCreated = CurrentGameObjects.Instance.GetPotionsCreated();

        slotPotionDictionary = new Dictionary<int, Potion>();

        // Loop through the potion inventory
        foreach (Potion aPotion in potionsCreated)
        {
            // There are currently only 8 slots available to populate
            if (slot <= 8)
            {
                // Add potion and slot number to dictionary to be used during selling
                slotPotionDictionary.Add(slot, aPotion);

                // Get the image from the Potion Opject and add it to the button, enable to button so the potion can be clicked
                theGameObject = GameObject.Find("Slot" + slot);
                theGameObject.GetComponent<Button>().enabled = true;
                theGameObject.GetComponent<Image>().sprite = aPotion.PotionImage;

                // Find the game object to place the text for potion information (name and coin value)
                theGameObject = GameObject.Find("Slot" + slot + "/Details");
                theGameObject.GetComponent<Text>().text = aPotion.PotionName + "\n" + "Value: " + aPotion.PotionCoinValue; 
            }

            slot += 1;
        }
    }

    //Reset slot count for inventory; this is needed to prevent duplicating inventory items when user opens inventory more then once
    private void Reset()
    {
        DisableButtons();
        this.slot = 1;
    }

    private void DisableButtons()
    {
        for (int aSlot = 1; aSlot <= 8; aSlot++)
        {
            GameObject.Find("Slot" + aSlot).GetComponent<Button>().enabled = false;

            GameObject.Find("Slot" + aSlot).GetComponent<Image>().color = unselectedSlotColor;
        }
    }

    public void HighlightSlot(int slotNumber)
    {
        GameObject.Find("Slot" + slotNumber).GetComponent<Image>().color = highlightSlotColor;
    }

    public void UnhighlightSlot(int slotNumber)
    {
        GameObject.Find("Slot" + slotNumber).GetComponent<Image>().color = unselectedSlotColor;
    }

    public Dictionary<int, Potion> SlotPotionDictionary
    {
        get { return this.slotPotionDictionary; }
    }

}
