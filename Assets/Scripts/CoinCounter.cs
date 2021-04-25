// Written by Rebecca Henry

using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public Text CoinCount;
    // Players current coin count

    void Update()
    {
        CoinCount.text = "0";
        // Update text to display the current coin count
    }
}
