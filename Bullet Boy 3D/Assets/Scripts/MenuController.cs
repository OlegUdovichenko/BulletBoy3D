using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text quantityCoins;
    public Text endLevelText;

    public Image firstObjective;
    public Image secondObjective;
    private int performed_objectives = 0;

    public GameObject menu;
    public GameObject nextLevelBtn;

    void Awake()
    {
        RefreshCoinsBar();
    }

    public void RefreshCoinsBar()
    {
        quantityCoins.text = Progress.instance.coins.ToString();
    }

    public void RefreshObjective()
    {
        if(performed_objectives == 0)
        {
            firstObjective.color = Color.red;
            performed_objectives++;
        }
        else
        {
            secondObjective.color = Color.red;
            performed_objectives++;
        }
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

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadSceneAsync(0);
    }
}
