using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float damage = 45f;
    public float delay = 3f;
    public float explosionForce = 700f;
    public GameObject explosion;
    public float radius = 10f;
    float countdown;
    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded){
            Explode();
        }
    }

    void Explode(){
        Instantiate(explosion, transform.position, transform.rotation);

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToDestroy){
            Destructable desturctable = nearbyObject.GetComponent<Destructable>();
            if(desturctable != null){
                desturctable.Die();
            }
            Explosive explosive = nearbyObject.GetComponent<Explosive>();
            if(explosive != null){
                explosive.Explode();
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in collidersToMove){
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null){
                rb.AddExplosionForce(explosionForce, transform.position, radius);

            }

            PlayerHealth health = nearbyObject.GetComponent<PlayerHealth>();
            if(health != null){
                health.TakeDamage((int)damage);
            }
        }

        Destroy(gameObject);
    }
}
