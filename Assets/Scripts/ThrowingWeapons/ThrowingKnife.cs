using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThrowingKnife : MonoBehaviour
{
    [SerializeField] GameObject ThrowingKnifePrefab;
    public int knifeDamage;
    [SerializeField] int knifeAmmo;
    [SerializeField] SpriteRenderer KnifeGFX;
    [SerializeField] Transform Knife;
    [SerializeField] float KnifeSpeed;

    public TMP_Text text;
    public Inventory Inv;
    bool CanThrow = true; //can safely remove

    private void Start()
    {
        Inv.arrowAmount = knifeAmmo;//need to change to knife ammount rather
        //than have it run on arrow ammount
    }

    private void Update()
    {

        text.text = "Ammo: " + knifeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(1) && CanThrow)
        {
            ThrowKnife();
            knifeAmmo--;
            Inv.arrowAmount = knifeAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Knife ammo left: " + knifeAmmo);//how much ammo is left
        }

        if (knifeAmmo == 0)
            CanThrow = false;

    }
    
    void ThrowKnife()
    {

        Debug.Log("Knife Damage: " + knifeDamage); //prints out how much damage each knife is doing/going to do

        float angle = Utility.AngleTowardsMouse(Knife.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Throw Throw = Instantiate(ThrowingKnifePrefab, Knife.position, rot).GetComponent<Throw>();
        knifeDamage = (int)Mathf.Ceil(knifeDamage);

        Throw.KnifeVelocity = KnifeSpeed;

        //CanThrow = false; //don't uncomment
        KnifeGFX.enabled = false;
    }
}
