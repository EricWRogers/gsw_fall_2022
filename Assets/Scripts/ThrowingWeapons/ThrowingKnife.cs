using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowingKnife : MonoBehaviour
{
    [SerializeField] GameObject ThrowingKnifePrefab;
    [SerializeField] int knifeDamage;
    [SerializeField] int knifeAmmo;
    [SerializeField] SpriteRenderer KnifeGFX;
    [SerializeField] Transform Knife;
    [SerializeField] float KnifeSpeed;

    public TMP_Text text;
    public Inventory Inv;
    bool CanThrow = true; //can safely remove

    private void Start()
    {
        Inv.arrowAmount = knifeAmmo;
        Destroy(gameObject, 2.5f);
    }

    private void Update()
    {

        text.text = "Ammo: " + knifeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(1) && CanThrow)
        {
            ThrowKnife();
            knifeAmmo--;
            Inv.arrowAmount = knifeAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Ammo left: " + knifeAmmo);//how much ammo is left
        }

        if (knifeAmmo == 0)
            CanThrow = false;

    }
    
    void ThrowKnife()
    {

        Debug.Log("Knife Damage: " + knifeDamage);

        float angle = Utility.AngleTowardsMouse(Knife.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Throw Throw = Instantiate(ThrowingKnifePrefab, Knife.position, rot).GetComponent<Throw>();
        knifeDamage = (int)Mathf.Ceil(knifeDamage);

        Throw.KnifeVelocity = KnifeSpeed;

        //CanThrow = false;
        KnifeGFX.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //enemy.TakeDamage(knifeDamage);
            collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(knifeDamage); //Logans Code. Works with Erics Health Script.
        }
        Destroy(gameObject); //destroys knives when they hit something
    }
}
