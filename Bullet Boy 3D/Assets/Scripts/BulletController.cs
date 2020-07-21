using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float _speed = 30;
    private bool _shot = false;
    public Aim a;

    private Vector3 p0, p1, p2;
    private float t = 0;

    void FixedUpdate()
    {
        if(_shot)
        {
            t+=0.01f;
            transform.position = Vector3.MoveTowards(transform.position,
                a.CalculateQuadraticBezierPoint(t, p0, p1, p2),
                _speed * Time.deltaTime);

            if(t >= 1)
                _shot = false;
        }
    }
    public void Shot(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        _shot = true;
        this.p0 = p0;
        this.p1 = p1;
        this.p2 = p2;
    }
}
