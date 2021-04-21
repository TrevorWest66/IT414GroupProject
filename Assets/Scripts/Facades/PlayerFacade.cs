//Written by Lance Graham
//4/21/2021
//This is the facade pattern in use; we must configure the player with these components in this order to ensure that the player is 
//configured correctly at the start of the game
//Without these components, the controls, in game menus, inventory, and mini game will not work correctly
using UnityEngine;

public class PlayerFacade
{
    public void Initialize(GameObject thePlayer, string name)
    {
        //add components for navigation, in game menues, and inventory
        thePlayer.AddComponent<Navigator>();
        thePlayer.AddComponent<InGameDisplay>();
        thePlayer.AddComponent<Inventory>();

        //Initialize mini game score to zero at start of game
        PlayerPrefs.SetInt("GrindingMiniGameScore", 0);

        //label the player
        thePlayer.tag = name;
    }
}
