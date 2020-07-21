using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountersController : MonoBehaviour
{
    public Text quantityCoins;
    public Image objective;

    public void RefreshCoinsBar()
    {
        quantityCoins.text = Progress.instance.coins.ToString();
    }
    public void RefreshObjective()
    {
        objective.color = Color.red;
    }
}
