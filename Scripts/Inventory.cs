using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Max Ammo")]
    public float maxPistolAmmo = 7f;
    public float maxRifleAmmo = 20f;
    public float maxShotgunAmmo = 3f;

    [Header("Ammo")]
    public float pistolAmmo= 0;
    public float storedPistolAmmo = 0;
    public float rifleAmmo= 0;

    [Header("Stored Ammo")]
    public float storedRifleAmmo = 0;
    public float shotgunAmmo= 0;
    public float storedShotgunAmmo = 0;

    [Header("Hkits/Grenades")]
    public int healthKits = 0;
    public int grenades = 0;

    [Header("UI Hkit/Grenades")]
    public Slider healSlider;
    public GameObject noneHeal;
    public Slider grenadeSlider;
    public GameObject noneGrenade;


    private void Update() {

        healSlider.value = healthKits;
        grenadeSlider.value = grenades;

        if(healthKits <= 0)
            noneHeal.SetActive(true);
        else
            noneHeal.SetActive(false);

        if(grenades <= 0)
            noneGrenade.SetActive(true);
        else
            noneGrenade.SetActive(false);


        if(pistolAmmo <=0)
            pistolAmmo = 0;
        if(pistolAmmo > maxPistolAmmo)
            pistolAmmo = maxPistolAmmo;

        if(rifleAmmo <=0)
            rifleAmmo = 0;
        if(rifleAmmo > maxRifleAmmo)
            rifleAmmo = maxRifleAmmo;

        if(shotgunAmmo <= 0)
            shotgunAmmo = 0;
        if(shotgunAmmo > maxShotgunAmmo)
            shotgunAmmo =maxShotgunAmmo;

          
    }

}
