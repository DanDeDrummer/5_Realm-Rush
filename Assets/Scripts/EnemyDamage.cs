using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] int hitpoints = 50;
    
    Tower tower;
    bool doDamage = true;

    private void Awake()
    {
        tower = FindObjectOfType<Tower>();
    }


    private void OnParticleCollision(GameObject other)
    {
        int damageDealt = 1;  
        TakeDamage(damageDealt);

        //die if hitpoints below 0
        if (hitpoints <= 0)
        {
            KillEnemy();
        }
        print("Damage:" + damageDealt);
    }

    private void TakeDamage(int damageDealt)
    {
        //Damege effect triggered
        hitParticlePrefab.Play();

        //Lose Hitpoints
        hitpoints = hitpoints - damageDealt;
        
    }

    private void KillEnemy()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticle.Play();
        float destroyDelay = deathParticle.main.duration;
        Destroy(deathParticle.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    
}
