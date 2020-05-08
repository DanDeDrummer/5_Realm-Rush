﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x, 0f, waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        Vector3 gridPos = waypoint.GetGridPos();
        string lableText = gridPos.x/ gridSize + "," + gridPos.y/ gridSize;
        gameObject.name = lableText;
        textMesh.text = lableText;
    }
}
