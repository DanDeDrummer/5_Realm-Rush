using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int baseHealth = 50;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip damageBaseSFX;

    private void Start()
    {
        healthText.text = "BaseHealth: " + baseHealth.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(damageBaseSFX);
        baseHealth = baseHealth - healthDecrease;
        healthText.text = "BaseHealth: " + baseHealth.ToString();
    }
}
