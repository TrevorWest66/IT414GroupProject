// Written by Trevor West
// 04/25/2021
// Class that creates a potion form a list of ingrediants

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCrafter
{
    private Potion CreatedPotion;

    public Potion DeterminePotion(List<string> ingredients)
    {
        // Creates a list of enums that contain the selected ingrediants
        List<CollectablePlantsEnum> plantEnum = new List<CollectablePlantsEnum>();
        foreach (string plants in ingredients)
        {
            if (plants.Equals("Rose"))
            {
                plantEnum.Add(CollectablePlantsEnum.Rose);
            }
            else if (plants.Equals("Wheatgrass"))
            {
                plantEnum.Add(CollectablePlantsEnum.Wheatgrass);
            }
            else if (plants.Equals("Cone Flower"))
            {
                plantEnum.Add(CollectablePlantsEnum.ConeFlower);
            }
            else if (plants.Equals("Ginger"))
            {
                plantEnum.Add(CollectablePlantsEnum.Ginger);
            }
            else if (plants.Equals("Spearmint"))
            {
                plantEnum.Add(CollectablePlantsEnum.Spearmint);
            }
            else if (plants.Equals("Lavender"))
            {
                plantEnum.Add(CollectablePlantsEnum.Lavender);
            }
            else if (plants.Equals("Chamomile"))
            {
                plantEnum.Add(CollectablePlantsEnum.Chamomile);
            }
            else if (plants.Equals("Nightshade"))
            {
                plantEnum.Add(CollectablePlantsEnum.Nightshade);
            }
            else if (plants.Equals("Mandrake"))
            {
                plantEnum.Add(CollectablePlantsEnum.Mandrake);
            }
        }

        // Create Strength Potion
        if (plantEnum.Contains(CollectablePlantsEnum.Rose))
        {
            if (plantEnum.Contains(CollectablePlantsEnum.Wheatgrass))
            {
                if (plantEnum.Contains(CollectablePlantsEnum.ConeFlower))
                {
                    CreatedPotion = new Potion("Strength Potion", 1000, plantEnum);
                }
            }
        }

        // Create Speed Potion
        if (plantEnum.Contains(CollectablePlantsEnum.Ginger))
        {
            if (plantEnum.Contains(CollectablePlantsEnum.ConeFlower))
            {
                if (plantEnum.Contains(CollectablePlantsEnum.Spearmint))
                {
                    CreatedPotion = new Potion("Speed Potion", 3000, plantEnum);
                }
            }
        }

        // Create Sleep Potion
        if (plantEnum.Contains(CollectablePlantsEnum.Lavender))
        {
            if (plantEnum.Contains(CollectablePlantsEnum.Chamomile))
            {
                if (plantEnum.Contains(CollectablePlantsEnum.Ginger))
                {
                    CreatedPotion = new Potion("Sleep Potion", 2000, plantEnum);
                }
            }
        }

        // Create Health Potion
        if (plantEnum.Contains(CollectablePlantsEnum.Aloe))
        {
            if (plantEnum.Contains(CollectablePlantsEnum.Lavender))
            {
                if (plantEnum.Contains(CollectablePlantsEnum.Rose))
                {
                    CreatedPotion = new Potion("Health Potion", 1000, plantEnum);
                }
            }
        }

        // Create Death Potion
        if (plantEnum.Contains(CollectablePlantsEnum.Aloe))
        {
            if (plantEnum.Contains(CollectablePlantsEnum.Lavender))
            {
                if (plantEnum.Contains(CollectablePlantsEnum.Rose))
                {
                    CreatedPotion = new Potion("Death Potion", 2000, plantEnum);
                }
            }
        }
        else
        {
            CreatedPotion = new Potion("Death Potion", 0, plantEnum);
        }

        CreatedPotion.PotionCoinValue *= PlayerPrefs.GetInt("GrindingMiniGameScore") / 20;

        return CreatedPotion;
    }
}
