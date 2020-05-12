using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] int numbertowerPlaced = 0;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Queue<Tower> towerQueue = new Queue<Tower>();


    public Waypoint baseWaypoint; //What tower standing on

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
        baseWaypoint.isPlaceable = false;

        //set base waypoints

        //put new tower in queue
        towerQueue.Enqueue(newTower);

        print("Number in queue " + numbertowerPlaced);
    }

    private void MoveExistingTower(Waypoint baseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        //set placable flags
        // baseWaypoint.isPlaceable = true;

        //set base waypoints

        //put old tower on to of queue
        towerQueue.Enqueue(oldTower);
        
    }


}
