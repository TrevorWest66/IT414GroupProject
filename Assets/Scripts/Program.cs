//Written by Lance Graham
//This is the main controller for the game where we initialize the game
using UnityEngine;

public class Program : MonoBehaviour
{
    private AbstractGameObjectFactory aFactory;
    private GameObject thePlayer;
    
    //Start is called before the first frame udpate
    void Start()
    {
        thePlayer = this.gameObject;
        thePlayer.AddComponent<Navigator>();
        thePlayer.AddComponent<InGameDisplay>();

        aFactory = new CauldronFactory();
        aFactory.CreateGameObject(new Vector3(0, 0, 0), 1.5f);
    }
}
