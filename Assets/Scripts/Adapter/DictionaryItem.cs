// Trevor West
// 04/25/2021
// A object that can be added to the dictionary

// Normal class
public class DictionaryItem
{
    public string Key { get; set; }
    public int Value { get; set; }

    // Constructor
    public DictionaryItem(string key, int value)
    {
        Key = key;
        Value = value;
    }

    // Add key value to the list of objects collected by player so far
    public virtual void AddToDictionary()
    {
        CurrentGameObjects.Instance.AddObjectsCollected(Key, Value);
    }
}
