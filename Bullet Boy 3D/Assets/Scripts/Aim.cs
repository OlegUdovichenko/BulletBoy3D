using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point0, point1;

    private int quantity_points = 100;
    private Vector3[] positions = new Vector3[100];
    // Start is called before the first frame update
    void Start()
    {
        //lineRenderer.SetVertexCount(quantity_points);
        lineRenderer.positionCount = quantity_points;
        DrawLinearCurve();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLinearCurve();
    }

    private void DrawLinearCurve()
    {
        float t;
        for(int i = 1; i < quantity_points + 1; i++)
        {
            t = i / (float)quantity_points;
            positions[i - 1] = CalculateLinearBezierPoint(t, point0.position, point1.position);
            //positions[i - 1].y -= 1;
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1)
    {
        return p0 + t * (p1 - p0);
    }
}
