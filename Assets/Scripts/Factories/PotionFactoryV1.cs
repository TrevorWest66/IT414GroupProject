// Written by Ellie McDonald
// 04/06/2021
// This class is version 1 of the Potion Factory, it creates the intial potions like strength, speed, sleep, health and death

using System.Collections.Generic;

class PotionFactoryV1 : AbstractPotionFactory
{
    public override List<Potion> CreatePotionRecipes()
    {
        // Create Strength Potion
        List<CollectablePlantsEnum> strengthPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Rose, CollectablePlantsEnum.Wheatgrass, CollectablePlantsEnum.ConeFlower};

        Potion strenthPotion = new Potion("Strength Potion", 1000, strengthPotionPlantIngredients);

        // Create Speed Potion
        List<CollectablePlantsEnum> speedPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Ginger, CollectablePlantsEnum.ConeFlower, CollectablePlantsEnum.Spearmint};

        Potion speedPotion = new Potion("Speed Potion", 3000, speedPotionPlantIngredients);

        // Create Sleep Potion
        List<CollectablePlantsEnum> sleepPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Lavender, CollectablePlantsEnum.Chamomile, CollectablePlantsEnum.Ginger};

        Potion sleepPotion = new Potion("Sleep Potion", 2000, sleepPotionPlantIngredients);

        // Create Health Potion
        List<CollectablePlantsEnum> healthPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Aloe, CollectablePlantsEnum.Lavender, CollectablePlantsEnum.Rose};

        Potion healthPotion = new Potion("Health Potion", 1000, healthPotionPlantIngredients);

        // Create Death Potion
        List<CollectablePlantsEnum> deathPotionPlantIngredients = new List<CollectablePlantsEnum>
        { CollectablePlantsEnum.Nightshade, CollectablePlantsEnum.Spearmint, CollectablePlantsEnum.Mandrake};

        Potion deathPotion = new Potion("Death Potion", 2000, deathPotionPlantIngredients);

        List<Potion> potionRecipesCreated = new List<Potion>
        { strenthPotion, speedPotion, sleepPotion, healthPotion, deathPotion };

        return potionRecipesCreated;

    }
}

