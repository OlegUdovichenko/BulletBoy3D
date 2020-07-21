using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text quantityCoins;
    public Text endLevelText;
    public Image objective;
    public GameObject menu;
    public GameObject nextLevelBtn;


    public void RefreshCoinsBar()
    {
        quantityCoins.text = Progress.instance.coins.ToString();
    }
    public void RefreshObjective()
    {
        objective.color = Color.red;
    }
    public void Result(bool result)
    {
        menu.SetActive(true);
        if(result)
        {
            endLevelText.text = "You Win!";
        }
        else
        {
            endLevelText.text = "You Lose:(";
            nextLevelBtn.SetActive(false);
        }
    }
}
