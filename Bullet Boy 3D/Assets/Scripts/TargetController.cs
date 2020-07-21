using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
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
