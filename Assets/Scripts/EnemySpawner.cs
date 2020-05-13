using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f,120f)] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] int numberEnemiesInLevel = 0, maxNumberEnemiesInLevel = 3;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text enemyCounter;
    [SerializeField] AudioClip spawnEnemySFX;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter.text = "Enemies: " + numberEnemiesInLevel.ToString();

        if (numberEnemiesInLevel < maxNumberEnemiesInLevel)
        {
            StartCoroutine(RepeatedlySpawnEnemies());
        }

        else
        {
            StopCoroutine(RepeatedlySpawnEnemies());
        }
    }


    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true)//forever
        {
            IncreaseEnemyCounter();
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    private void IncreaseEnemyCounter()
    {
        numberEnemiesInLevel++;
        enemyCounter.text = "Enemies: " + numberEnemiesInLevel.ToString();
    }
}
