// Trevor West
// 04/25/2021
// Adapts a potion object to be added as a dictionaryItem

using UnityEngine;

public class PotionDictAdapter
{

    // Takes an potion and changes it to bne able to go into the dictionary that is the inventory
    public void AddPotionToDictionary(string value, int key)
    {
        // Create a unique potion name for the dictionary key
        value += Time.time.ToString();
        // Potions don't stack
        key = 1;

        CurrentGameObjects.Instance.AddObjectsCollected(value, key);
    }
}
