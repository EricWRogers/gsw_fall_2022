using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public PlayerWeaponManager PWM;
    public GameObject player;

    [HideInInspector] public float KnifeVelocity;
    private void Start()
    {
        player = GameObject.Find("Player");
        PWM = player.GetComponent<PlayerWeaponManager>(); //Changed from the ThrowingKnife Script because it is offically depricated - Logan

        rb.velocity = transform.up * KnifeVelocity;
        Destroy(gameObject, 10f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
                                  //in this case 10 seconds before they disappear
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");
            collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(PWM.knifeDamage); //Logans Code. Works with Erics Health Script.
            Debug.Log(collision);
        }
        Destroy(gameObject); //destroys knives when they hit something
    }
}
