﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Aim aim;
    public MenuController menu;

    [SerializeField]
    private int quantity_shots = 1;

    private int _shots = 0;
    private float _speed = 1f;
    private bool _shot = false;
    private bool _rebound = false;

    private Vector3 _p0, _p1, _p2;
    private float _t = 0;
    private int bullet_hit_target = 0;
    

    void FixedUpdate()
    {
        if(_shot)
        {
            _t += _speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,
                aim.CalculateQuadraticBezierPoint(_t, _p0, _p1, _p2), _speed);

            if(_t >= 1)
            {
                EndShot();
            }
        }
        else if(_rebound)
        {
            _t+=0.04f;

            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.2f),
                _speed * Time.deltaTime * 10f);

            if(_t >= 1)
            {
                EndShot();
            }
        }
    }
    public void Shot(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        if(!_shot)
        {
            _shot = true;
            _p0 = p0;
            _p1 = p1;
            _p2 = p2;
        }
    }

    public void EndShot()
    {
        _shots++;
        _shot = false;
        _rebound = false;

        if(_shots == quantity_shots)
        {
            Destroy(gameObject);
            menu.Result(bullet_hit_target >= _shots);
        }
        else
        {
            transform.position = _p0;
            _t = 0;
            aim.lineRenderer.positionCount = aim.quantity_points;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        CoinController coin = collider.GetComponent<CoinController>();
        TargetController target = collider.GetComponent<TargetController>();
        if(coin)
        {
            Progress.instance.coins++;
            menu.RefreshCoinsBar();
        }
        else if(target)
        {
            bullet_hit_target++;
            menu.RefreshObjective();
        }
        else
        {
            _shot = false;
            _rebound = true;
        }
    }
}
