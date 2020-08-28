using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KILL : MonoBehaviour {

    public int damage = 1000;

    PlayerHealth playerHealth;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
