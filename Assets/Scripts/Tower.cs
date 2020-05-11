using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [SerializeField] int damageDealt = 1;
    bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        LookAt();
        isActive = !isActive;
        //ShootEnemy(isActive);
    }

    private void LookAt()
    {
        objectToPan.LookAt(targetEnemy);
    }

    /*private void ShootEnemy(bool isActive)
    {
        var particleSystem = turret.GetComponent<ParticleSystem>().emission;
        particleSystem.enabled = isActive;       
    }*/

    public int GetDamageDealt()
    {
        return damageDealt;
    }

 
}
