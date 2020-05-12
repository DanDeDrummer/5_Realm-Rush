using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] int hitpoints = 50;
    int damageDealt;
    Tower tower;
    bool doDamage = true;

    private void Awake()
    {
        tower = FindObjectOfType<Tower>();
    }


    private void OnParticleCollision(GameObject other)
    {      
        damageDealt = 1; //tower.GetDamageDealt()
        TakeDamage(damageDealt);
        print("Damage:" + damageDealt);
    }

    private void TakeDamage(int damageDealt)
    {
        //Damege effect triggered
        hitParticlePrefab.Play();

        //Lose Hitpoints
        hitpoints = hitpoints - damageDealt;
        

        //die if hitpoints below 0
        if (hitpoints <= 0)
        {
            var deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
            deathParticle.Play();
            float destroyDelay = deathParticle.main.duration;
            Destroy(deathParticle.gameObject, destroyDelay);
            Destroy(gameObject);                      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
