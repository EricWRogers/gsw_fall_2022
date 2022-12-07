using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PoisonManager : MonoBehaviour
{

    public float poisonSpeed;
    public int poisonDamage;
    public int poisonAmmo;

    public GameObject PoisonPrefab;
    public Transform Pois;

    public SpriteRenderer PoisonGFX;


    public TMP_Text text;
    public Inventory Inv;


    bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("THIS IS BAD FIX!");
        Inv.arrowAmount = poisonAmmo; //need to change to knife ammount rather
                                       //than have it run on arrow ammount

    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
            text.text = "Ammo: " + poisonAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(0) && CanThrow)
        {
            ThrowPoison();
            poisonAmmo--;
            Inv.arrowAmount = poisonAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Molotov ammo left: " + poisonAmmo);//how much ammo is left

        }

        if (poisonAmmo == 0)
            CanThrow = false;
    }

    void ThrowPoison()
    {
        Debug.Log("Poison Damage: " + poisonDamage); //prints out how much damage each grenade is doing/going to do

        float angle = Utility.AngleTowardsMouse(Pois.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        ChuckMolotov Chuck = Instantiate(PoisonPrefab, Pois.position, rot).GetComponent<ChuckMolotov>();
        Chuck.MolotovVelocity = poisonSpeed;

        PoisonGFX.enabled = false;
    }
}
