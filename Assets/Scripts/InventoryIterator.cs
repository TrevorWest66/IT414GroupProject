//Written by Lance Graham
//This is the first concrete iterator that will iterate through the game objects collected by the player
using System.Collections;
using System.Collections.Generic;
using System;

public class InventoryIterator : AbstractIterator
{
    private Dictionary<string, int> collectedObjects;
    private int currentValue = 0;
    private List<string> theKeys;

    //Public constructor grabs the dictionary from the CurrentGameObjects Singleton and initiliazes the instance variable
    //I also put all of the keys into an instance variable to help with iterating through the dictionary
    public InventoryIterator()
    {
        this.collectedObjects = CurrentGameObjects.Instance.getObjectsCollected();
        this.theKeys = new List<string>(this.collectedObjects.Keys);
    }

    //Overridden method responsible for determining if we have looped through the complete dictionary
    public override bool hasNext()
    {
        if(currentValue < theKeys.Count)
        {
            return true;
        }
        return false;
    }

    //Overridden method will grab the next key value pair in the dictionary if there is one
    //We abstractly specify an Object return type which is the parent directly or indirectly for all objects
    public override Object next()
    {
        if (this.hasNext())
        {
            //Current key to look at
            string key = theKeys[currentValue];
            
            int value;
            
            //Current value for the key
            this.collectedObjects.TryGetValue(key, out value);

            //Increment our counter; this will determine whether we've looped through all key value pairs
            this.currentValue++;

            //return the key value pair
            return new KeyValuePair<string, int>(key, value);

        }
        return null;
    }
}
