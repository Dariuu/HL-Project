using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject weapon;
    GameObject weaponHolder;

    // Start is called before the first frame update
    void Start()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("Weapon Holder");
    }

    public void PickUp() {
        GameObject weaponClone = Instantiate(weapon, weaponHolder.transform.position, weaponHolder.transform.rotation);
        weaponClone.transform.parent = weaponHolder.transform;
        Destroy(gameObject);
    }

}
