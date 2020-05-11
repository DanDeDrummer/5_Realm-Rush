using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject damageEffect;
    [SerializeField] int hitpoints = 50;
    int damageDealt;
    Tower tower;

    private void Awake()
    {
        tower = FindObjectOfType<Tower>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start hitpoints: " + hitpoints);
    }


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Ow on collision by " + other.name);
        damageDealt = tower.GetDamageDealt();
        print(damageDealt);
        TakeDamage(damageDealt);       
    }

    private void TakeDamage(int damageDealt)
    {
        //Damege effect triggered
        damageEffect.SetActive(true);

        //Lose Hitpoints
        hitpoints = hitpoints - damageDealt;
        

        //die if hitpoints below 0
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
