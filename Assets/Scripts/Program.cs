//Written by Lance Graham
//This is the main controller for the game where we initialize the game
using UnityEngine;

public class Program : MonoBehaviour
{
    private AbstractGameObjectFactory aFactory;
    private GameObject thePlayer;
    private PlantSpawner aPlantSpawner;

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
        aFactory.CreateGameObject(new Vector3(0, .5f, 0), 1.5f);

        //This is only used to populate the inventory for the phase 2 demonstration since we can't pick up objects yet
        //This will be all be deleted

        GameObject one = new GameObject();
        one.name = "Cone Flower";

        GameObject two = new GameObject();
        two.name = "Cone Flower";

        GameObject three = new GameObject();
        three.name = "Rose";

        GameObject four = new GameObject();
        four.name = "Rose";

        GameObject five = new GameObject();
        five.name = "Rose";

        GameObject six = new GameObject();
        six.name = "Spearmint";

        CurrentGameObjects aSingleton = CurrentGameObjects.Instance;
        aSingleton.addObjectsCollected(three);
        aSingleton.addObjectsCollected(four);
        aSingleton.addObjectsCollected(five);
        aSingleton.addObjectsCollected(one);
        aSingleton.addObjectsCollected(two);
        aSingleton.addObjectsCollected(six);
    }
}
