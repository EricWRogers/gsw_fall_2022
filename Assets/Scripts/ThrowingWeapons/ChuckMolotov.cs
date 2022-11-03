using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckMolotov : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    public MolotovManager MN;
    public GameObject player;


    public float delay = 2f; //how long before the grenade explodes
    public float countDown;

    public float force, radius;

    [HideInInspector] public float MolotovVelocity;
    private void Start()
    {
        MN = player.GetComponent<MolotovManager>();
        countDown = delay;

        rb.velocity = transform.up * MolotovVelocity;
    }

    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f)
        {
            Shatter();

        }
    }

    public void Shatter()
    {

        //show visual effects
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        //get nearby objects
        Vector2 origin = transform.position;


        //adds the force to each collider in the radius, therefore pushing them back

        foreach (Collider2D nearbyObject in Physics2D.OverlapCircleAll(origin, radius))
        {
            if (nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>() != null)
            {
                //int damage = (int)((1 - ((Vector2)nearbyObject.transform.position - (Vector2)gameObject.transform.position).magnitude/radius) * GN.grenadeDamage);
                int damage = (int)Mathf.Ceil(((1 - Vector2.Distance((Vector2)nearbyObject.transform.position, (Vector2)gameObject.transform.position) / radius) * MN.MolotovDamage));
                
                nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(damage);
                //^ deals damage to every nearby object.

                //add force, pushes stuff away if they have a rigidbody
                Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    //rb.AddForce((transform.position.x, transform.position.y).magnitude);
                    //obviously gonna have to be edited to fit the force stuff
                }
            }
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
