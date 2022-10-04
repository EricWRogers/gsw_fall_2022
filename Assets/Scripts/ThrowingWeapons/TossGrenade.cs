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
        Destroy(gameObject, 2f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
                                  //in this case 2 seconds before they disappear
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");
            //Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            //enemy.health -= 100;
            //enemy.TakeDamage(knifeDamage);
            collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(GN.grenadeDamage); //Logans Code. Works with Erics Health Script.
            Debug.Log(collision);
        }
        Destroy(gameObject); //destroys knives when they hit something
    }
}
