using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point0, point1, point2;
    public BulletController bulletController;
    public int quantity_points = 100;

    private Vector3[] _positions = new Vector3[100];
    private Vector3 touch_position;
    private float _speed = 50;

    void Start()
    {
        lineRenderer.positionCount = quantity_points;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            touch_position = Input.mousePosition;
            touch_position.z = 50;
            touch_position = Camera.main.ScreenToWorldPoint(touch_position);

            touch_position.x = Mathf.Clamp(touch_position.x, -13, 13);
            
            point2.position = Vector3.MoveTowards(point2.position, new Vector3(touch_position.x, 
                point2.position.y, point2.position.z), _speed*Time.deltaTime);

            point1.position = Vector3.MoveTowards(point1.position, new Vector3(-touch_position.x, 
                point1.position.y, point1.position.z), _speed * Time.deltaTime);

            DrawQuadraticCurve();
        }

        if(Input.GetMouseButtonUp(0))
        {
            lineRenderer.positionCount = 0;
            bulletController.Shot(point0.position, point1.position, point2.position);
        }
    }

    private void DrawQuadraticCurve()
    {
        float t;
        for(int i = 1; i < quantity_points + 1; i++)
        {
            t = i / (float)quantity_points;
            _positions[i - 1] = CalculateQuadraticBezierPoint(t, point0.position, point1.position, point2.position);
        }
        lineRenderer.SetPositions(_positions);
    }

    public Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        return ((1 - t) * (1 - t) * p0) + (2 * (1 - t) * t * p1) + (t * t * p2);
    }
}
