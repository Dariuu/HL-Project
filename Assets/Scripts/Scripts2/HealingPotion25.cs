using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion25 : MonoBehaviour {

    PlayerHealth playerHealth;
    GameObject player;

    public float amount = 25;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerHealth.currentHealth < 100 && other.gameObject == player)
        {
            playerHealth.AddHealth(amount);
            Destroy(gameObject);
        }
    }
}
