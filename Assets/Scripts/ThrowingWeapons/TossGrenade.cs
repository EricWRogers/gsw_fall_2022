using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossGrenade : MonoBehaviour
{

    
    [SerializeField] Rigidbody2D rb;
    public Grenade GN;
    public GameObject player;

    [HideInInspector] public float GrenadeVelocity;
    private void Start()
    {
        GN = player.GetComponent<Grenade>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * GrenadeVelocity;
        //Destroy(gameObject, 2f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
                                  //in this case 2 seconds before they disappear
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
}
