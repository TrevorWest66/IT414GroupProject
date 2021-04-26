// Trevor West
// 04/25/2021
// Adapts a potion object to be added as a dictionaryItem

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionDictAdapter
{

    // takes an potion and changes it to bne able to go into the dictionary that is the inventory
    public void AddPotionToDictionary(string value, int key)
    {
        // create a unique potion name for the dictionary key
        value += Time.time.ToString();
        // potions don't stack
        key = 1;

        CurrentGameObjects.Instance.AddObjectToInventory(value, key);
    }
}
