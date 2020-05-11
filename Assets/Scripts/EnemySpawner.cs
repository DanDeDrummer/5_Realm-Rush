using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] int numberEnemiesInLevel = 0, maxNumberEnemiesInLevel = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (numberEnemiesInLevel < maxNumberEnemiesInLevel)
        {
            StartCoroutine(RepeatedlySpawnEnemies());
        }

        else
        {
            StopCoroutine(RepeatedlySpawnEnemies());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)//forever
        {
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns);
            //Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity);
           // numberEnemiesInLevel++;
            //print("number hostiles in level: " + numberEnemiesInLevel);
        }

    }
}
