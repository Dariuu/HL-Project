using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public GameObject enemy;

    public float spawnCoolDown = 5f;
    public float spawnCoolDownTimer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnCoolDownTimer == 0)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            spawnCoolDownTimer = spawnCoolDown;
        }

        if (spawnCoolDownTimer > 0)
        {
            spawnCoolDownTimer -= Time.deltaTime;
        }

        if (spawnCoolDownTimer < 0)
        {
            spawnCoolDownTimer = 0;
        }

    }

}
