using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [HideInInspector] public float ArrowVelocity;

    [HideInInspector] public int ArrowDamage;

    [SerializeField] Rigidbody2D rb;
    

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * ArrowVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //enemy.TakeDamage(ArrowDamage);
            Debug.Log("Arrow : Hi");
            collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(ArrowDamage); //Logans Code. Works with Erics Health Script.
        }
        Destroy(gameObject); //destroys arrows when they hit something
    }
}