using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    GameObject gameManager;
    Inventory ammo;
    Camera cam;
    public ParticleSystem flash;
    public GameObject[] bulletHole;
    public float attackCoolDownTimer;
    public AudioSource sound;
    public WeaponProprieties weapon;
    public float throwForce = 20f;
    public GameObject grenade;
    Animator animator;

    private void Awake() {
        cam = Camera.main;
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        ammo = gameManager.GetComponent<Inventory>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float pistolReload = ammo.maxPistolAmmo - ammo.pistolAmmo;
        float rifleReload = ammo.maxRifleAmmo - ammo.rifleAmmo;
        float shotgunReload = ammo.maxShotgunAmmo - ammo.shotgunAmmo;

        animator.SetBool("shoot", false);



        if (attackCoolDownTimer > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }

        if (attackCoolDownTimer < 0)
        {
            attackCoolDownTimer = 0;
        }

        if (Input.GetKey(KeyCode.Mouse0) && attackCoolDownTimer == 0)
        {
            switch(weapon.ammoType){
                case WeaponProprieties.AmmoType.pistol:
                    if(ammo.pistolAmmo >=1){
                        ammo.pistolAmmo -= 1f;
                        flash.Play();          
                        Fire();
                        sound.clip = weapon.sounds[Random.Range(0, weapon.sounds.Length)];
                        sound.Play ();
                        attackCoolDownTimer = weapon.attackCoolDown;
                        animator.SetBool("shoot", true);
                    }
                    else if(ammo.pistolAmmo <= 0){
                        Debug.Log("no bullets!");
                        animator.SetBool("shoot", false);
                    }
                break;

                case WeaponProprieties.AmmoType.rifle:
                    if(ammo.rifleAmmo >=1){
                        ammo.rifleAmmo-= 1f;
                        flash.Play();          
                        Fire();
                        sound.clip = weapon.sounds[Random.Range(0, weapon.sounds.Length)];
                        sound.Play ();
                        attackCoolDownTimer = weapon.attackCoolDown;
                    }else if(ammo.rifleAmmo <= 0){
                        Debug.Log("no bullets!");
                    }
                        
                break;

                case WeaponProprieties.AmmoType.shotgun:
                    if(ammo.shotgunAmmo >=1){
                        ammo.shotgunAmmo -=1f;
                        flash.Play();      

                        int amountOfProjectiles = (int)weapon.maxProjectile;
                        for(int i = 0; i < amountOfProjectiles; i++)
                        {
                            ShotgunFire();
                        }

                        sound.clip = weapon.sounds[Random.Range(0, weapon.sounds.Length)];
                        sound.Play ();
                        attackCoolDownTimer = weapon.attackCoolDown;
                        animator.SetBool("shoot", true);
                    }else if(ammo.shotgunAmmo <= 0){
                        Debug.Log("no bullets!");
                        animator.SetBool("shoot", false);
                    }
                break;
            }
        } 

        if(Input.GetKeyDown(KeyCode.R)){
            switch(weapon.ammoType){
                case WeaponProprieties.AmmoType.pistol:
                    if(ammo.storedPistolAmmo >= pistolReload){
                        ammo.pistolAmmo += pistolReload;
                        ammo.storedPistolAmmo -= pistolReload;
                    }
                    else if(ammo.storedPistolAmmo < pistolReload){
                        ammo.pistolAmmo += ammo.storedPistolAmmo; 
                        ammo.storedPistolAmmo = 0;
                    }  
                break;

                case WeaponProprieties.AmmoType.rifle:
                    if(ammo.storedRifleAmmo >= rifleReload){
                        ammo.rifleAmmo += rifleReload;
                        ammo.storedRifleAmmo -= rifleReload;
                    }
                    else if(ammo.storedRifleAmmo < rifleReload){
                        ammo.rifleAmmo += ammo.storedRifleAmmo; 
                        ammo.storedRifleAmmo = 0;
                    }  
                break;

                case WeaponProprieties.AmmoType.shotgun:
                    if(ammo.storedShotgunAmmo >= shotgunReload){
                        ammo.shotgunAmmo += shotgunReload;
                        ammo.storedShotgunAmmo -= shotgunReload;
                    }
                    else if(ammo.storedShotgunAmmo < shotgunReload){
                        ammo.shotgunAmmo += ammo.storedShotgunAmmo;
                        ammo.storedShotgunAmmo = 0; 
                    }                 
                break;
            }
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
            }
            else if (hit.transform.gameObject.tag == "Player")
            {
                //Nothing
            }
            else
            {
                BulletHole(hit);
            }
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
        }
    }

    public void ShotgunFire(){
        Vector3 direction = cam.transform.forward; // your initial aim.
        Vector3 spread = new Vector3();
        spread += cam.transform.up * Random.Range(-1f, 1f); // add random up or down (because random can get negative too)
        spread += cam.transform.right * Random.Range(-1f, 1f); // add random left or right

        // Using random up and right values will lead to a square spray pattern. If we normalize this vector, 
        //we'll get the spread direction, but as a circle.
        // Since the radius is always 1 then (after normalization), we need another random call. 
        direction += spread.normalized * Random.Range(0f, 0.2f);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, direction, out hit, weapon.range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", weapon.damage);                
            }
            else if(hit.rigidbody)
            {
                hit.rigidbody.AddForceAtPosition(weapon.force * direction, hit.point);
                hit.transform.gameObject.SendMessage("TakeDamage", weapon.damage);
                BulletHole(hit);
            }
            else if (hit.transform.gameObject.tag == "Player")
            {
                //Nothing
            }
            else
            {
                BulletHole(hit);
            }
            Debug.DrawLine(cam.transform.position, hit.point, Color.green);
        }
    }
    public void BulletHole(RaycastHit hit)
    {
        GameObject clone;
        clone = Instantiate(bulletHole[Random.Range(0,3)], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
        clone.transform.parent = hit.transform;
        Destroy(clone, 10f);
    }


}
