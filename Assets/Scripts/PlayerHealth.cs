using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHealth = 50;
    [SerializeField] int healthDecrease = 1;


    private void OnTriggerEnter(Collider other)
    {
        
        baseHealth = baseHealth - healthDecrease;
        print(baseHealth);
    }
}
