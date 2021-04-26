// Trevor West
// 04/25/2021
// A object that can be added to the dictionary

using System.Collections;
using System.Collections.Generic;

// normal class
public class DictionaryItem
{
    public string Key { get; set; }
    public int Value { get; set; }

    public DictionaryItem(string key, int value)
    {
        Key = key;
        Value = value;
    }

    public virtual void AddToDictionary()
    {
        CurrentGameObjects.Instance.AddObjectToInventory(Key, Value);
    }
}
