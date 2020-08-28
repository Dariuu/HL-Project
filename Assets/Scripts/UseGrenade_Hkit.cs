using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGrenade_Hkit : MonoBehaviour
{
    Camera cam;
    GameObject gameManager;
    Inventory ammo;
    public float throwForce = 20f;
    public GameObject grenade;
    PlayerHealth health;
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        ammo = gameManager.GetComponent<Inventory>();

        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && health.currentHealth < 99){
            if(ammo.healthKits >=1){
                ammo.healthKits -=1;
                health.currentHealth += 25f;
            }else if(ammo.healthKits <= 0){
                Debug.Log("no kits!");
            }
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            if(ammo.grenades >=1){
                ammo.grenades -=1;
                ThrowGrenade();
            }else if(ammo.grenades <= 0){
                Debug.Log("no grenades!");
            }
        }
    }

    void ThrowGrenade(){
        GameObject grenadeClone = Instantiate(grenade, cam.transform.position, cam.transform.rotation);
        Rigidbody rb = grenadeClone.GetComponent<Rigidbody>();
        rb.AddForce(cam.transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
