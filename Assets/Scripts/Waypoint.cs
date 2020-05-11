using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    public bool isExplored = false;
    public bool isPlaceable = true;
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
                Debug.Log("Clicked on placeable block " + gameObject.name);              
            }
            else
            {
                Debug.Log("Can't place that here");
            }



        }
    }

   


    private void Update()
    {
        
    }
}
