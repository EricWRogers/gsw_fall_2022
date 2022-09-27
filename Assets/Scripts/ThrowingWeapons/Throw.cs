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
    }
}
