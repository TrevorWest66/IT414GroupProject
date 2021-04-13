// Written By Ellie McDonald
// 04/09/21
// This class iterates can iterate through a list of potions from the potion factory

using System.Collections.Generic;
using UnityEngine;

public class PotionRecipeIterator : AbstractIterator
{
    private PotionRecipeSingleton potionRecipeSingleton;
    private List<Potion> recipesForPotions;
    private int currentValue = 0;

    public PotionRecipeIterator()
    {
        potionRecipeSingleton = PotionRecipeSingleton.Instance;
        AbstractPotionFactory potionFactory = potionRecipeSingleton.PotionFactory;
        this.recipesForPotions = potionFactory.CreatePotionRecipes();
    }
    public override bool hasNext()
    {
        if (currentValue < recipesForPotions.Count)
        {
            return true;
        }
        return false;
    }

    public override object next()
    {
        if (this.hasNext())
        {
            // Current potion to look at
            Potion aPotion = recipesForPotions[currentValue];

            // Increment our counter; this will determine whether we've looped through all the potions
            this.currentValue++;

            //return the potion
            return aPotion;

        }
        return null;
    }
}
