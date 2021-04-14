// Written by Ellie McDonald
// 04/06/2021
// Class that holds details about a given potion

using System.Collections.Generic;

public class Potion
{
    private string potionName;
    private int potionBaseCoinValue;
    private List<CollectablePlantsEnum> plantsInPotion;

    public string PotionName
    {
        get { return this.potionName; }
        set { this.potionName = value; }
    }

    public int PotionCoinValue
    {
        get { return this.potionBaseCoinValue; }
        set { this.potionBaseCoinValue = value; }
    }

    public List<CollectablePlantsEnum> PlantsInPotion
    {
        get { return this.plantsInPotion; }
        set { this.plantsInPotion = value; }
    }

    public Potion(string potionName, int potionCoinValue, List<CollectablePlantsEnum> plantsInPotionRecipe)
    {
        PotionName = potionName;
        PotionCoinValue = potionCoinValue;
        PlantsInPotion = plantsInPotionRecipe;
    }
}
