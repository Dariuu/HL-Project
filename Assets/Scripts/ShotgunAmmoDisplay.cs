using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShotgunAmmoDisplay : MonoBehaviour
{
    public TextMeshProUGUI mainAmmo;
    public TextMeshProUGUI storedAmmo;

    GameObject gameManager;
    Inventory inv;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        inv = gameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        mainAmmo.text = inv.shotgunAmmo.ToString();
        storedAmmo.text = inv.storedShotgunAmmo.ToString();
    }
}
