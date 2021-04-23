// Ellie McDonald
// 04/23/2021
// This class controls populating the potion inventory for selling
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class PotionInventory
{
    private GameObject theGameObject;
    private AbstractIterator anIterator;
    private Sprite theSprite;
    private int slot = 1;

    private System.Random random = new System.Random();

    public void PopulateInventory()
    {
        anIterator = new PotionInventoryIterator();

        // Reset slot so that inventory always starts populating at slot 1
        Reset();

        // Check to verify there are objects in the inventory and there are open slots available
        // Currently there are 8 slots total on the canvas
        while (anIterator.hasNext() && slot < 9)
        {
            //Get key value pair from iterator
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)anIterator.next();

            string key = keyValue.Key;
            int value = keyValue.Value;

            //Load a random 2d sprite image located in the Resources/Potions folder
            theSprite = Resources.Load<Sprite>("/Potions/PotionImage" + random.Next(1,3));

            //Find the game object to place that sprite (the 2d image)
            theGameObject = GameObject.Find("Slot " + slot);
            theGameObject.GetComponent<Image>().sprite = theSprite;

            //Find the game object to place the text for potion information (name and coin value)
            theGameObject = GameObject.Find("Slot (" + slot + ")/Potion Info");
            theGameObject.GetComponent<Text>().text = key + "\n" + "Value: " + value;

            slot += 1;
        }
    }

    //Reset slot count for inventory; this is needed to prevent duplicating inventory items when user opens inventory more then once
    public void Reset()
    {
        this.slot = 1;
    }
}
