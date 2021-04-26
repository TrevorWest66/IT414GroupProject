// Trevor West
// 04/25/2021
// Adapter to call the specialized method to turn a potion into a format that can be added to the dictionary

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adapter : DictionaryItem
{
    private PotionDictAdapter potionAdapter = new PotionDictAdapter();

    public Adapter(string key, int value) : base(key, value) { }

    public override void AddToDictionary()
    {
        potionAdapter.AddPotionToDictionary(Key, Value);
    }
}
