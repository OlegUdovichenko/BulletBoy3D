using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        BulletController bullet = collider.GetComponent<BulletController>();

        if(bullet)
        {
            Destroy(gameObject);
        }
    }
}
