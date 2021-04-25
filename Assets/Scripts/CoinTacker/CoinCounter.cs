// Written by Rebecca Henry
// 4/23/21
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text CoinCount;
    // Players current coin count

    void Update()
    {
        CoinCount.text = "0"; // player preferences for score
        // Update text to display the current coin count
    }
}
