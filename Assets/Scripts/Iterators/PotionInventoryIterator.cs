// Ellie McDonald
// 04/23/21
// This class can be used to iterate through a dictionary of potions in the collected objects singleton
using System.Collections.Generic;
using UnityEngine;

class PotionInventoryIterator : AbstractIterator
{
    private Dictionary<string, int> potions;
    private int currentValue = 0;
    private List<string> theKeys;

    // Public constructor grabs only the potions dictionary from the CurrentGameObjects Singleton
    public PotionInventoryIterator()
    {
        this.potions = CurrentGameObjects.Instance.GetPotionsCollected();
        this.theKeys = new List<string>(this.potions.Keys);
    }

    // Overridden method responsible for determining if we have looped through the complete dictionary
    public override bool hasNext()
    {
        if (currentValue < theKeys.Count)
        {
            return true;
        }
        return false;
    }

    // Overridden method will grab the next key value pair in the dictionary if there is one
    public override object next()
    {
        if (this.hasNext())
        {
            //Current key to look at
            string key = theKeys[currentValue];

            int value;

            //Current value for the key
            this.potions.TryGetValue(key, out value);

            //Increment our counter; this will determine whether we've looped through all key value pairs
            this.currentValue++;

            //return the key value pair
            return new KeyValuePair<string, int>(key, value);

        }
        return null;
    }
}
