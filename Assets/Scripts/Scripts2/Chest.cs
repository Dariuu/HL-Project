using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject loot;
    public bool isOpen;

	// Use this for initialization
	void Start () {
        isOpen = false;
	}

    public void Open()
    {
        if (isOpen == false)
        {
            Instantiate(loot, transform.position, transform.rotation);
            isOpen = true;
        }
    }
}
