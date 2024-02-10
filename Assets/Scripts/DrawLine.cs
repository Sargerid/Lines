using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class DrawLine : MonoBehaviour
{
    private int positionCount = 0; // quantity of points in line 
    private bool isDrawing = false;
    
    //components
    private LineRenderer lr;
    private Rigidbody2D rb;
    EdgeCollider2D edgeCollider;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Start()
    {
        //line basic settings
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.positionCount = 0;
        
    }

    void Update()
    {
        // check if mouse button was pressed
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        // check if mouse button still held
        else if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        // check if mouse button was abbandoned
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        positionCount = 0;
        lr.positionCount = positionCount;
        rb.isKinematic = true;
    }

    void ContinueDrawing()
    {
        if (isDrawing)
        {
            // increasing  amount of points and update line position 
            positionCount++;
            lr.positionCount = positionCount;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get mouse position
            mousePosition.z = 0;
            lr.SetPosition(positionCount - 1, mousePosition);
        }
    }

    void StopDrawing()
    {
        isDrawing = false;
        SetEdgeCollider(lr);
    }
    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
 
        for(int point = 0; point<lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }
 
        edgeCollider.SetPoints(edges);
    }
}
