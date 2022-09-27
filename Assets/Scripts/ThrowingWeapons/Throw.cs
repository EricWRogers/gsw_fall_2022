using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;


    [HideInInspector] public float KnifeVelocity;
    private void FixedUpdate()
    {
        rb.velocity = transform.up * KnifeVelocity;
        Destroy(gameObject, 2f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
                                  //in this case 2 seconds before they disappear
    }
}
