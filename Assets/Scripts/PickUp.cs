using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    GameObject gameManager;
    public PickUpProprieties pickUp;
    Inventory data;
    
    private void Awake() {
        
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        data = gameManager.GetComponent<Inventory>();
        
    }

    public void Get() {
        switch(pickUp.pickUpType)
        {
            //pistol
            case PickUpProprieties.PickUpType.pistol:
            if(data.pistolAmmo == data.maxPistolAmmo){
                data.pistolAmmo = data.maxPistolAmmo;
                data.storedPistolAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            else if(data.pistolAmmo > data.maxPistolAmmo){
                data.pistolAmmo = data.maxPistolAmmo;
            }
            else if(data.pistolAmmo < 0){
                data.pistolAmmo = 0;
            }  
            else if (data.pistolAmmo < data.maxPistolAmmo){
                data.pistolAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            break;

            //rifle
            case PickUpProprieties.PickUpType.rifle:
            if(data.rifleAmmo == data.maxRifleAmmo){
                data.rifleAmmo = data.maxRifleAmmo;
                data.storedRifleAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            else if(data.rifleAmmo > data.maxRifleAmmo){
                data.rifleAmmo = data.maxRifleAmmo;
            }
            else if(data.rifleAmmo < 0){
                data.rifleAmmo = 0;
            }  
            else if (data.rifleAmmo < data.maxRifleAmmo){
                data.rifleAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            break;

            //shotgun
            case PickUpProprieties.PickUpType.shotgun:
            if(data.shotgunAmmo == data.maxShotgunAmmo){
                data.shotgunAmmo = data.maxShotgunAmmo;
                data.storedShotgunAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            else if(data.shotgunAmmo > data.maxShotgunAmmo){
                data.shotgunAmmo = data.maxShotgunAmmo;
            }
            else if(data.shotgunAmmo < 0){
                data.shotgunAmmo = 0;
            }  
            else if (data.shotgunAmmo < data.maxShotgunAmmo){
                data.shotgunAmmo += pickUp.amount;
                Destroy(this.gameObject);
            }
            break;

            //grenade
            case PickUpProprieties.PickUpType.grenade:
            if(data.grenades == data.grenadeSlider.maxValue){
                data.grenades = (int)data.grenadeSlider.maxValue;
            }
            else if(data.grenades > data.grenadeSlider.maxValue){
                data.grenades = (int)data.grenadeSlider.maxValue;
            }
            else if(data.grenades < 0){
                data.grenades = 0;
            }  
            else if (data.grenades < data.grenadeSlider.maxValue){
                data.grenades += (int)pickUp.amount;
                Destroy(this.gameObject);
            }
            break;

            //healKit
            case PickUpProprieties.PickUpType.healthKit:
            if(data.healthKits == data.healSlider.maxValue){
                data.healthKits = (int)data.healSlider.maxValue;
            }
            else if(data.healthKits > data.healSlider.maxValue){
                data.healthKits = (int)data.healSlider.maxValue;
            }
            else if(data.healthKits < 0){
                data.healthKits = 0;
            }  
            else if (data.healthKits < data.healSlider.maxValue){
                data.healthKits += (int)pickUp.amount;
                Destroy(this.gameObject);
            }
            break;  

        }
            
    }

    
}
