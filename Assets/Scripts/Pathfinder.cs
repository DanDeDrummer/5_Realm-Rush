using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

    Vector2Int[] directions = { Vector2Int.up , Vector2Int.right, Vector2Int.down, Vector2Int.left  };
    bool isRunnig = true;

    private void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        Pathfind();
        //ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print("Search from: " + searchCenter);
            HaltIfEndFound(searchCenter);

           
        }

        print("Finished search?");


    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Same same");//remove if work
            isRunnig = false;
            return;
        }
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
            }
            catch { }
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();

            //Check Overlapping
            bool isOverlapping = grid.ContainsKey(gridPos);

            if (isOverlapping)
            {
                Debug.LogWarning("Skipping Overlapping blocks at: " + waypoint);
            }
            else
            {
                //Add to Dictonary
                grid.Add(gridPos, waypoint);
            }
        }       
    }
}
