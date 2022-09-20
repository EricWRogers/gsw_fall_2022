using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowingKnife : MonoBehaviour
{

    [SerializeField] int knifeDamage;
    [SerializeField] int knifeAmmo;

    /*public TMP_Text text;
    public Inventory Inv;
    bool CanThrow = true; //can safely remove

    private void Start()
    {
        Inv.arrowAmount = knifeAmmo;
        Destroy(gameObject, 2.5f);
    }*/

    /*private void Update()
    {

        text.text = "Ammo: " + knifeAmmo.ToString();
        if (Input.GetMouseButtonUp(1) && CanThrow)
        {
            ThrowKnife();
            knifeAmmo--;
            Inv.arrowAmount = knifeAmmo;//ammo stuff
            Debug.Log("Ammo left: " + knifeAmmo);//ammo stuff
        }

        if (knifeAmmo == 0)
            CanThrow = false;

    }
    
    void ThrowKnife()
    {

        Debug.Log("Knife Damage: " + knifeDamage);

        float angle = Utility.AngleTowardsMouse(Bow.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Arrow Arrow = Instantiate(ArrowPrefab, Bow.position, rot).GetComponent<Arrow>();
        Arrow.ArrowVelocity = ArrowSpeed;
        Arrow.ArrowDamage = (int)Mathf.Ceil(ArrowDamage);

        CanThrow = false;
        ArrowGFX.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Attacked");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //enemy.TakeDamage(ArrowDamage);
            collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(ArrowDamage); //Logans Code. Works with Erics Health Script.
        }
        Destroy(gameObject); //destroys knives when they hit something
    }*/
}
