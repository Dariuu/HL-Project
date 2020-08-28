using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PickUp")]
public class PickUpProprieties : ScriptableObject
{
    public float amount;

    public enum PickUpType
    {
        pistol, rifle, shotgun, grenade, healthKit
    }

    public PickUpType pickUpType;

}