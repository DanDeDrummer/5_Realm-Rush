using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] int numbertowerPlaced = 0;
    [SerializeField] Tower towerPrefab;

    public void AddTower(Waypoint baseWaypoint)
    {

        if (numbertowerPlaced < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }

        else
        {
            //Remove oldest tower replace with newest
            MoveExistingTower();
        }
    }

    private void MoveExistingTower()
    {
        print("Tower Limit reached mate.");
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        numbertowerPlaced++;
        baseWaypoint.isPlaceable = false;
    }
}
