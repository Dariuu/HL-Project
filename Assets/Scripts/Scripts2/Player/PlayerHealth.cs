using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour {

    public int startHealth = 100;
    public float currentHealth;
    public float regenerationSpeed = 1;
    public Slider healthSlider;

    public Transform PlayerTransform;
    public Transform RespawnPoint;

    void PlayerHealth ()
    {
        Debug.Log("contrusctor ");

    }

    void Awake()
    {
        currentHealth = startHealth;
    }

    void Update()
    {
        if (currentHealth <= 100)
        {
            currentHealth += regenerationSpeed * Time.deltaTime;
            healthSlider.value = currentHealth;
        }
        if (currentHealth <= 0.2)
        {
            PlayerTransform = RespawnPoint;
            currentHealth = startHealth;
        }
        if(currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        healthSlider.value = currentHealth;
    }
}
