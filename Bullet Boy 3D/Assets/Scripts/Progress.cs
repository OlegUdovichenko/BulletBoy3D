using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress instance;
    public int coins = 0;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }
}
