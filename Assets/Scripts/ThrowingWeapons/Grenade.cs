using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Grenade : MonoBehaviour
{

    public float delay = 2f; //how long before the grenade explodes
    public float radius = 4f; // how large the explosion is
    public float force = 250f;
    public float grenadeSpeed;
    public int grenadeDamage;
    public int grenadeAmmo;

    public GameObject GrenadePrefab;
    public Transform Gren;

    //public SpriteRenderer explosionEffect;
    public SpriteRenderer GrenadeGFX;

    float countDown;

    public TMP_Text text;
    public Inventory Inv;

    bool hasExploded = false;
    bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        Inv.arrowAmount = grenadeAmmo; //need to change to knife ammount rather
        //than have it run on arrow ammount
        countDown = delay;

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Ammo: " + grenadeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(1) && CanThrow)
        {
            ThrowGrenade();
            grenadeAmmo--;
            Inv.arrowAmount = grenadeAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Ammo left: " + grenadeAmmo);//how much ammo is left

            countDown -= Time.deltaTime;
            if (countDown <= 0f && hasExploded == false)
            {
                Debug.Log("BOOM");
                Explode();
                hasExploded = true;
            }
        }

        if (grenadeAmmo == 0)
            CanThrow = false;
    }

    void ThrowGrenade()
    {

        Debug.Log("Knife Damage: " + grenadeDamage); //prints out how much damage each knife is doing/going to do

        float angle = Utility.AngleTowardsMouse(Gren.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        TossGrenade Toss = Instantiate(GrenadePrefab, Gren.position, rot).GetComponent<TossGrenade>();
        grenadeDamage = (int)Mathf.Ceil(grenadeDamage);

        Toss.GrenadeVelocity = grenadeSpeed;

        //CanThrow = false; //don't uncomment
        GrenadeGFX.enabled = false;
    }

    void Explode()
    {
        //show visual effects
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        //adds the force to each collider in the radius, therefore pushing them back
        foreach (Collider nearbyObject in colliders)
        {
            //add force, pushes stuff away if they have a rigidbody
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
    }
}
