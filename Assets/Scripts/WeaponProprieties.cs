using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon")]
public class WeaponProprieties : ScriptableObject
{
    public float range = 0f;

    
    [Header("Used only by shotgun!")]
    [Header("-")]
    [Tooltip("Used only by the shotgun!")]
    public float maxProjectile;
    [Header("-")]
    public int damage = 0;
    public float force;
    public float attackCoolDown;
    public AudioClip[] sounds;

    public enum AmmoType
    {
        pistol, rifle, shotgun, none
    };

    public AmmoType ammoType;
}
