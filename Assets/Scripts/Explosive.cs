using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public int startHealth = 50;
    public float currentHealth;
    public float damage = 50f;
    public float explosionForce = 700f;
    public GameObject explosion;
    public float radius = 10f;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Explode();
        }
        if(currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }
        if(currentHealth < 0){
            currentHealth = 0;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

    }

    public void Explode(){
        Instantiate(explosion, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy){
            Destructable desturctable = nearbyObject.GetComponent<Destructable>();
            if(desturctable != null){
                desturctable.Die();
            }
            Explosive explosive = nearbyObject.GetComponent<Explosive>();
            if(explosive != null){
                explosive.TakeDamage((int)damage);
            }
            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if(health != null){
                health.TakeDamage((int)damage);
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove){
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null){
                rb.AddExplosionForce(explosionForce, transform.position, radius);

            }
        }

        Destroy(gameObject);
    }
}
