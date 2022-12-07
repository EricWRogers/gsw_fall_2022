using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YeetPoison : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    public PoisonManager PN;
    public GameObject player;

    public ParticleSystem poisBubble;


    public float delay = 2f; //how long before the molotov shatters
    public float countDown;
    public float burnTimer = 0.0f;
    public float tickTimer = 1.0f;
    public float tickRate = 1.0f;

    public float /*force*/ radius;

    [HideInInspector] public float MolotovVelocity;
    private void Start()
    {
        PN = player.GetComponent<PoisonManager>();
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
        burnTimer += Time.deltaTime;
        int damage = PN.poisonDamage;
        Instantiate(poisBubble.gameObject, transform.position, transform.rotation);
        if (tickTimer >= tickRate)
        {
            tickTimer = 0.0f;
            foreach (Collider2D nearbyObject in Physics2D.OverlapCircleAll(origin, radius))
            {
                if (nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>() != null)
                {

                    nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(damage);
                }
            }
        }
        else
        {
            tickTimer += Time.deltaTime;
        }
        //Destroy(gameObject);

        if (burnTimer >= 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
