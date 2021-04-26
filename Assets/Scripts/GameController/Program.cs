// Written by Lance Graham
// 03/14/2021
// This is the main controller for the game where we initialize the game

using UnityEngine;

public class Program : MonoBehaviour
{
    private GameObject thePlayer;
    private PlayerFacade theFacade;

    // Start is called before the first frame udpate
    void Start()
    {
        // Initialize the player
        thePlayer = this.gameObject;

        // Create a facade object
        theFacade = new PlayerFacade();

        // The facade takes care of the player initialization since this must be done correctly every time to ensure optimal user experience
        theFacade.Initialize(thePlayer, "Player");
    }
}
