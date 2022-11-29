using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public int damage;

    private Inventory Inv;
    private void Start()
    {
        Inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        //damage = Inv.items[Inv.currentItem].itemStats.GetComponent<SwordStats>().damage;
        damage = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Corruption"))
        {
            other.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(damage);
        }
        
    }
}
