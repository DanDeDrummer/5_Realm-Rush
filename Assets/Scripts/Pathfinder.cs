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
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunnig)
        {
            var searchCenter = queue.Dequeue(); 
            print("Search from: " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;

        }

        //todo work out path
        print("Finished search?");


    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Serching from end node, therfore stopping");//remove if work
            isRunnig = false;
            
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunnig) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch
            {
                //do nothing
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored)
        {
            //do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.blue);//todo move later
            queue.Enqueue(neighbour);
            print("Queueing" + neighbour.name);
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
