// Written by Ellie McDonald
// 04/06/2021
// Abstract Potion Factory class, extend this class for subsequent versions of a potion factory

using System.Collections.Generic;

public abstract class AbstractPotionFactory
{
    public abstract List<Potion> CreatePotionRecipes(List<CollectablePlantsEnum> listOfPlantsForRecipe);
}

