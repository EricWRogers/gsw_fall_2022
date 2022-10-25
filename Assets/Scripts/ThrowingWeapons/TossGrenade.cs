using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossGrenade : MonoBehaviour
{

    
    [SerializeField] Rigidbody2D rb;
    public GrenadeManager GN;
    public GameObject player;

    public float delay = 2f; //how long before the grenade explodes
    public float countDown;

    [HideInInspector] public float GrenadeVelocity;
    private void Start()
    {
        GN = player.GetComponent<GrenadeManager>();
        countDown = delay;
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * GrenadeVelocity;
        //Destroy(gameObject, 2f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
        //in this case 2 seconds before they disappear

    }
    void Update()
    {

        countDown -= Time.deltaTime;
        if (countDown <= 0f && GN.hasExploded == false)
        {
            Debug.Log("BOOM");
            Explode();
            GN.hasExploded = true;
            //collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(GN.grenadeDamage); 
            //^ could be put in the actual explode function, maybe. it should still work if that's done.
            //^ Logans Code. Works with Erics Health Script.
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");

            if (GN.countDown <= 0f && GN.hasExploded == false)
            {
                Debug.Log("BOOM");
                GN.Explode();
                GN.hasExploded = true;
                collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(GN.grenadeDamage); //Logans Code. Works with Erics Health Script.
            }
            //Debug.Log(collision);
        }
        //Destroy(gameObject); //destroys grenades when they hit something,
        //don't need cause they destroy when they explode
    }*/

    public void Explode()
    {
        //show visual effects
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        //get nearby objects
        /*Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        //adds the force to each collider in the radius, therefore pushing them back
        foreach (Collider nearbyObject in colliders)
        {
            //add force, pushes stuff away if they have a rigidbody
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }*/
        Destroy(gameObject);
    }
}
