//Written by Lance Graham
//4/21/2021
//This class is responsible for spawning the crafting cauldron at game startup
//Eventually we would have additional logic for spawning the cauldron which is why we created a separate class for it (follows SOLID)

using UnityEngine;

public class CraftingSpawner : MonoBehaviour
{
    private AbstractGameObjectFactory aFactory;

    // Start is called before the first frame update
    void Start()
    {
        //Create the crafting station
        aFactory = new CauldronFactory();
        aFactory.CreateGameObject(new Vector3(0, .5f, 0), 1.5f);
    }
}
