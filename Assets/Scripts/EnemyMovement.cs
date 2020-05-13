using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = .5f;
    [SerializeField] ParticleSystem goalParticlePrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();//Is ok to do this way because only one Pathfinder
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol");
        foreach (Waypoint waypoint in path)
        {  
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementSpeed); 
        }
        DamageBase();
    }

    private void DamageBase()
    {
        var goalParticle = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        goalParticle.Play();
        float destroyDelay = goalParticle.main.duration;
        Destroy(goalParticle.gameObject, destroyDelay);
        Destroy(gameObject);
    }


}
