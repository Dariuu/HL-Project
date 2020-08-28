using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int startHealth = 50;
    public float currentHealth;
    public GameObject broken;
    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0.2)
        {
            Die();
        }
        if(currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

    }
    
    public void Broken()
    {
        GameObject clone;     
        clone = Instantiate(broken, origin.transform.position, origin.transform.rotation);
        Destroy(clone, 10f);
    }

    public void Die()
    {
        Broken();
        Destroy(gameObject);
    }
}
