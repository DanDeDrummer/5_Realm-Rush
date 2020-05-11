using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] int damageDealt = 1;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectileParticle;

   

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            LookAt();
            ShootAtEnemy();
        }

        else
        {
            Shoot(false);
        }
    }

    private void LookAt()
    {
        objectToPan.LookAt(targetEnemy);
    }

    private void ShootAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);

        if (distanceToEnemy <= attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
  
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

    public int GetDamageDealt()
    {
        return damageDealt;
    }

 
}
