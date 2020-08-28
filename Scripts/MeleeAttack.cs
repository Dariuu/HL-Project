using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    GameObject gameManager;
    Inventory ammo;
    Camera cam;
    public GameObject[] hole;
    public float attackCoolDownTimer;
    public AudioSource sound;
    public WeaponProprieties weapon;
    public float throwForce = 20f;
    public GameObject grenade;

    private void Awake() {
        cam = Camera.main;
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        ammo = gameManager.GetComponent<Inventory>();
    }

    void Update()
    {
        if (attackCoolDownTimer > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }

        if (attackCoolDownTimer < 0)
        {
            attackCoolDownTimer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCoolDownTimer == 0)
        {          
            Fire();
            sound.clip = weapon.sounds[Random.Range(0, weapon.sounds.Length)];
            sound.Play ();
            attackCoolDownTimer = weapon.attackCoolDown;
        }   

    }

    public void Fire()
    {
        Vector3 direction = cam.transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, weapon.range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", weapon.damage);                
            }
            else if(hit.rigidbody)
            {
                hit.rigidbody.AddForceAtPosition(weapon.force * direction, hit.point);
                hit.transform.gameObject.SendMessage("TakeDamage", weapon.damage);
                Hole(hit);
            }
            else if (hit.transform.gameObject.tag == "Player")
            {
                //Nothing
            }
            else
            {
                Hole(hit);
            }
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
        }
    }

    public void Hole(RaycastHit hit)
    {
        GameObject clone;
        clone = Instantiate(hole[Random.Range(0,3)], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        clone.transform.parent = hit.transform;
        Destroy(clone, 10f);
    }

}
