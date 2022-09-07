using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 0;

    public float maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
