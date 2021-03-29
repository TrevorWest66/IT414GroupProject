//Written by Lance Graham
//Written 3/24/2021
//This class is responsible for populating they player's inventory
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private GameObject theGameObject;
    private Sprite theSprite;
    private AbstractIterator anIterator;
    private int slot = 1;
    public void PopulateInventory()
    {
        //Our abstract iterator initialized to our concrete InventoryIterator to iterate through the collected game objects
        anIterator = new InventoryIterator();

        //Reset slot so that inventory always populates at slot 1
        Reset();

        //Check to verify there are objects in the inventory; we also only have 12 slots
        while (anIterator.hasNext() && slot < 13)
        {
            //Get key value pair from iterator
            KeyValuePair<string, int> keyValue = (KeyValuePair<string, int>)anIterator.next();

            string key = keyValue.Key;
            int value = keyValue.Value;

            //Load the 2d sprite image located in the Resources folder
            theSprite = Resources.Load<Sprite>(key + " Image");

            //Find the game object to place that sprite (the 2d image)
            theGameObject = GameObject.Find("Slot (" + slot + ")/Image");
            theGameObject.GetComponent<Image>().sprite = theSprite;

            //Find the game object to place the text for the game object name
            theGameObject = GameObject.Find("Slot (" + slot + ")/Name");
            theGameObject.GetComponent<Text>().text = key;

            //Find the game object to place the text for the quanity of that game object
            theGameObject = GameObject.Find("Slot (" + slot + ")/Quantity");
            theGameObject.GetComponent<Text>().text = value.ToString();

            slot += 1;
        }

        //We have clicked the crafting button so set that static variable to true (will disable the crafting canvas and enable the inventory canvas)
        Cursor.lockState = CursorLockMode.None;
        InGameDisplay.craftingClicked = true;

        //The back button has not been clicked yet as the inventory canvas hasn't been displayed so we set this static variable to false
        InGameDisplay.backClicked = false;
    }

    //Reset slot count for inventory; this is needed to prevent duplicating inventory items when user opens inventory more then once
    public void Reset()
    {
        this.slot = 1;
    }
}
