// Written by Ellie McDonald
// 04/11/2021
// This class ensures there is only 1 instance of the possible potion recipes in the game
// When more potion factories are made, they can be updated here
// This needs to be a singleton because the potion factory is used across classes 

public class PotionRecipeSingleton
{
    private static PotionRecipeSingleton instance = null;
    private AbstractPotionFactory potionFactory = new PotionFactoryV1();
    public static PotionRecipeSingleton Instance 
    { 
        get { return PotionRecipeSingleton.instance; }
    }

    static PotionRecipeSingleton()
    {
        // Change the factory version here
        PotionRecipeSingleton.instance = new PotionRecipeSingleton();
    }

    public AbstractPotionFactory PotionFactory
    {
        get { return this.potionFactory; }
    }
}

