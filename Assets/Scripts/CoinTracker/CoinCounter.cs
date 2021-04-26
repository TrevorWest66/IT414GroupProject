// Written by Rebecca Henry
// 4/23/21
// This class is used to update the player preferences for the player's current coin total 

using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    // Players current coin count
    public Text CoinCount;

    void Update()
    {
        // Update text to display the current coin count
        CoinCount.text = "0"; // player preferences for score
    }
}
