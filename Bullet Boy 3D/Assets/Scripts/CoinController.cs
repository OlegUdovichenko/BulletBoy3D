using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        BulletController bullet = other.GetComponent<BulletController>();

        if(bullet)
        {
            Destroy(gameObject);
        }
    }
}
