using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] int numbertowerPlaced = 0;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();


    

    public void AddTower(Waypoint baseWaypoint)
    {   
        numbertowerPlaced = towerQueue.Count;
        print("Tower limit is: " + towerLimit);

        if (numbertowerPlaced < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);    
        }

        else
        {
            //Remove oldest tower replace with newest
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        //set base waypoints
        newTower.baseWaypoint = baseWaypoint;

        //put new tower in queue
        towerQueue.Enqueue(newTower);

        print("Number in queue " + numbertowerPlaced);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
       
        oldTower.baseWaypoint.isPlaceable = true;//free up the block
        newBaseWaypoint.isPlaceable = false;

        //set base waypoints
        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;

        //put old tower on to of queue
        towerQueue.Enqueue(oldTower);
        
    }


}
