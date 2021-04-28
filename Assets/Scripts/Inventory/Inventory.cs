// Written by Lance Graham
// 03/24/2021
// This class is responsible for populating they player's inventory

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private GameObject theGameObject;
    private Sprite theSprite;
    private AbstractIterator anIterator;
    private Potion aPotion;
    private int slot = 1;

    public void PopulateInventory()
    {
        // Our abstract iterator initialized to our concrete InventoryIterator to iterate through the collected game objects
        anIterator = new InventoryIterator();

        // Reset slot so that inventory always starts populating at slot 1
        Reset();

        // Check to verify there are objects in the inventory; we also only have 12 slots
        while (anIterator.hasNext() && slot < 13)
        {
            // Get key value pair from iterator
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)anIterator.next();

            string key = keyValue.Key;
            int value = keyValue.Value;

            if (key.Substring(0,3).Equals("PID")) 
            {
                foreach (Potion potion in CurrentGameObjects.Instance.GetPotionsCrafted())
                {
                    if (potion.KeyName.Equals(key))
                    {
                        aPotion = potion;
                    }
                }
                // Get the image from the Potion Object
                theGameObject = GameObject.Find("Slot (" + slot + ")/Image");
                theGameObject.GetComponent<Image>().sprite = aPotion.PotionImage;

                // Find the game object to place the text for potion information (name and coin value)
                theGameObject = GameObject.Find("Slot (" + slot + ")/Name");
                theGameObject.GetComponent<Text>().text = aPotion.PotionName;

                // Find the game object to place the text for the quanity of that game object
                theGameObject = GameObject.Find("Slot (" + slot + ")/Quantity");
                theGameObject.GetComponent<Text>().text = aPotion.PotionCoinValue.ToString();
            }
            else
            {
                // Load the 2d sprite image located in the Resources folder
                theSprite = Resources.Load<Sprite>(key + " Image");

                // Find the game object to place that sprite (the 2d image)
                theGameObject = GameObject.Find("Slot (" + slot + ")/Image");
                theGameObject.GetComponent<Image>().sprite = theSprite;

                // Find the game object to place the text for the game object name
                theGameObject = GameObject.Find("Slot (" + slot + ")/Name");
                theGameObject.GetComponent<Text>().text = key;

                // Find the game object to place the text for the quanity of that game object
                theGameObject = GameObject.Find("Slot (" + slot + ")/Quantity");
                theGameObject.GetComponent<Text>().text = value.ToString();
            }

            slot += 1;
        }
    }

    // Reset slot count and the items in the inventory
    public void Reset()
    {
        for (int aSlot = 1; aSlot < 13; aSlot++)
        {
            GameObject.Find("Slot (" + aSlot + ")/Image").GetComponent<Image>().sprite = null;
            GameObject.Find("Slot (" + aSlot + ")/Name").GetComponent<Text>().text = null;
            GameObject.Find("Slot (" + aSlot + ")/Quantity").GetComponent<Text>().text = null;
        }

        this.slot = 1;
    }

}
