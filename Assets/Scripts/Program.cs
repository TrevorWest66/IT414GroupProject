﻿//Written by Lance Graham
//This is the main controller for the game where we initialize the game
using UnityEngine;

public class Program : MonoBehaviour
{
    private AbstractGameObjectFactory aFactory;
    private GameObject thePlayer;
    
    //Start is called before the first frame udpate
    void Start()
    {
        //Initialize the player by adding navigation and the in game display (player's actions determine crafting button and inventory display)
        thePlayer = this.gameObject;
        PlayerPrefs.SetInt("GrindingMiniGameScore", 0);

        thePlayer.AddComponent<Navigator>();
        thePlayer.AddComponent<InGameDisplay>();

        //Create the crafting station
        aFactory = new CauldronFactory();
        aFactory.CreateGameObject(new Vector3(0, .7f, 0), 1.5f);
    }
}
