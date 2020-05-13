using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] int hitpoints = 50;
    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    int enemyDamage;
    
    Tower tower;
    AudioSource myAudioSource;
    

    private void Awake()
    {
        tower = FindObjectOfType<Tower>();
        myAudioSource = GetComponent<AudioSource>();
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
    }

    private void TakeDamage(int damageDealt)
    {
        //Damege effect triggered
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyHitSFX);

        //Lose Hitpoints
        hitpoints = hitpoints - damageDealt;
        
    }

    private void KillEnemy()
    {
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticle.Play();
        //myAudioSource().PlayOneShot(killedEnemy);
        float destroyDelay = deathParticle.main.duration;
        Destroy(deathParticle.gameObject, destroyDelay);
        Destroy(gameObject);
    }

    public int GetEnemyDamage()
    {
        return enemyDamage;
    }


    
}
