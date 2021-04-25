// Written by Ellie McDonald
// 04/06/2021
// Class that holds details about a given potion
using UnityEngine;
using System.Collections.Generic;

public class Potion
{
    private string potionName;
    private int potionCoinValue;
    private Sprite potionImage;
    private List<CollectablePlantsEnum> plantsInPotion;

    private System.Random random = null;

    public string PotionName
    {
        get { return this.potionName; }
        set { this.potionName = value; }
    }

    public int PotionCoinValue
    {
        get { return this.potionCoinValue; }
        set { this.potionCoinValue = value; }
    }

    public Sprite PotionImage
    {
        get { return this.potionImage; }
        set { this.potionImage = value; }
    }

    public List<CollectablePlantsEnum> PlantsInPotion
    {
        get { return this.plantsInPotion; }
        set { this.plantsInPotion = value; }
    }

    // Constructor
    public Potion(string potionName, int potionCoinValue, List<CollectablePlantsEnum> plantsInPotionRecipe)
    {
        random = new System.Random();
        PotionName = potionName;
        PotionCoinValue = potionCoinValue;
        PlantsInPotion = plantsInPotionRecipe;
        potionImage = Resources.Load<Sprite>("Potion" + random.Next(1,3).ToString());
    }
}
