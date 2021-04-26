// Trevor West
// 04/25/2021
// Adapter to call the specialized method to turn a potion into a format that can be added to the dictionary

public class Adapter : DictionaryItem
{
    private PotionDictAdapter potionAdapter = new PotionDictAdapter();

    // Constructor
    public Adapter(string key, int value) : base(key, value) { }

    // Add potion to the list of objects collected by the player
    public override void AddToDictionary()
    {
        potionAdapter.AddPotionToDictionary(Key, Value);
    }
}
