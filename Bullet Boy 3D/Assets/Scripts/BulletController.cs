using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Aim aim;
    public CanvasController canvas;

    private float _speed = 10;
    private bool _shot = false;

    private Vector3 _p0, _p1, _p2;
    private float _t = 0;
    private bool bullet_hit_target = false;
    

    void FixedUpdate()
    {
        if(_shot)
        {
            _t+=0.01f;
            transform.position = Vector3.MoveTowards(transform.position,
                aim.CalculateQuadraticBezierPoint(_t, _p0, _p1, _p2),
                _speed * Time.deltaTime);

            if(_t >= 1)
            {
                _shot = false;
                Destroy(gameObject);
                canvas.Result(bullet_hit_target);
            }
        }
    }
    public void Shot(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        _shot = true;
        _p0 = p0;
        _p1 = p1;
        _p2 = p2;
    }

    void OnTriggerEnter(Collider other)
    {
        CoinController coin = other.GetComponent<CoinController>();
        TargetController target = other.GetComponent<TargetController>();
        if(coin)
        {
            Progress.instance.coins++;
            canvas.RefreshCoinsBar();
        }
        else if(target)
        {
            bullet_hit_target = true;
            canvas.RefreshObjective();
        }
    }
}
