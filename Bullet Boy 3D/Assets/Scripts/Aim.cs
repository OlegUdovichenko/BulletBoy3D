using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point0, point1;

    private int quantity_points = 100;
    private Vector3[] _positions = new Vector3[100];

    private Vector3 touch_position;
    private float speed = 50;
    private int aim_range = 30;
    private Vector3 start_position_point;

    void Start()
    {
        lineRenderer.positionCount = quantity_points;
        start_position_point = point1.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            touch_position = Input.mousePosition;
            touch_position.z = 10;
            touch_position = Camera.main.ScreenToWorldPoint(touch_position);

            touch_position.x = touch_position.x > 8 ? 8 : touch_position.x;
            touch_position.x = touch_position.x < -8 ? -8 : touch_position.x;

            //point1.position.z = aim_range;
            
            point1.position = Vector3.MoveTowards(point1.position, new Vector3(touch_position.x, 
                point1.position.y, aim_range), speed*Time.deltaTime);

            DrawLinearCurve();
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("0");
            point1.position = start_position_point;
        }
    }

    private void DrawLinearCurve()
    {
        float t;
        for(int i = 1; i < quantity_points + 1; i++)
        {
            t = i / (float)quantity_points;
            _positions[i - 1] = CalculateLinearBezierPoint(t, point0.position, point1.position);
        }
        lineRenderer.SetPositions(_positions);
    }

    private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        return p0 + t * (p1 - p0);
    }
}
