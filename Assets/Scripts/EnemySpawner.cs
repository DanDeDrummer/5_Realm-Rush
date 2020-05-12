using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f,120f)] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] int numberEnemiesInLevel = 0, maxNumberEnemiesInLevel = 3;
    [SerializeField] Transform enemyParentTransform;

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
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }
}
