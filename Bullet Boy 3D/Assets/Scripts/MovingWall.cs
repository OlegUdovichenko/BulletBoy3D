using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    private float _speed = 3;
    private float _direction = 1;

    void FixedUpdate()
    {
        if(transform.position.x >= 3)
            _direction = -1;
        else if(transform.position.x <= -3.5f)
            _direction = 1;

        transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x + 0.2f * _direction, transform.position.y, transform.position.z),
                _speed * Time.deltaTime);
    }
}
