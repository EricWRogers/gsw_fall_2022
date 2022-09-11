using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBullet : MonoBehaviour
{
   
    public int arrowDamage = 10;
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update

    void Awake()
    {
        
       
    }
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

   void OnTriggerEnter2D(Collider2D hitInfo)
   {
    if(hitInfo.CompareTag("Player"))
    {
        hitInfo.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(arrowDamage); //Logans Code. Works with Erics Health Script.
        Destroy(gameObject);
    }
   }
}
