using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GrenadeManager : MonoBehaviour
{
    public float radius = 4f; // how large the explosion is
    //public float force = 250f;
    public float grenadeSpeed;
    public int grenadeDamage;
    public int grenadeAmmo;

    public GameObject GrenadePrefab;
    public Transform Gren;

    //public SpriteRenderer explosionEffect;
    public SpriteRenderer GrenadeGFX;


    public TMP_Text text;
    public Inventory Inv;

    
    bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        Inv.arrowAmount = grenadeAmmo; //need to change to knife ammount rather
        //than have it run on arrow ammount

    }

    // Update is called once per frame
    void Update() //changing to fixed update makes it to where you can't spam fire the grenade
    {
        text.text = "Ammo: " + grenadeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(0) && CanThrow)
        {
            ThrowGrenade();
            grenadeAmmo--;
            Inv.arrowAmount = grenadeAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Grenade ammo left: " + grenadeAmmo);//how much ammo is left

        }

        if (grenadeAmmo == 0)
            CanThrow = false;
    }

    void ThrowGrenade()
    {
        Debug.Log("Grenade Damage: " + grenadeDamage); //prints out how much damage each grenade is doing/going to do

        float angle = Utility.AngleTowardsMouse(Gren.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        TossGrenade Toss = Instantiate(GrenadePrefab, Gren.position, rot).GetComponent<TossGrenade>();

        Toss.GrenadeVelocity = grenadeSpeed;

        GrenadeGFX.enabled = false;
    }

    
}
