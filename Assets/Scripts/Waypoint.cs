using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public Waypoint exploredFrom;

    Vector2Int gridPos;
    const int gridSize = 10;




    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        int x = Mathf.RoundToInt(transform.position.x / gridSize);
        int y = Mathf.RoundToInt(transform.position.z / gridSize);

        return new Vector2Int(x, y);
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse over " + gameObject.name);
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse  no longer over over " + gameObject.name);
    }


    private void Update()
    {
        
    }
}
