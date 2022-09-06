using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    private float health;

    [SerializeField] private float maxHealth;

    private void start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        Debug.Log("Enemy Health" + health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
