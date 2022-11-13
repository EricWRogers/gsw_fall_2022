using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MolotovManager : MonoBehaviour
{

    public float molotovSpeed;
    public float molotovDamage;
    public int molotovAmmo;

    public GameObject MolotovPrefab;
    public Transform Molo;

    public SpriteRenderer MolotovGFX;


    public TMP_Text text;
    public Inventory Inv;


    bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        Inv.arrowAmount = molotovAmmo; //need to change to knife ammount rather
                                       //than have it run on arrow ammount

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Ammo: " + molotovAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(0) && CanThrow)
        {
            ThrowMolotov();
            molotovAmmo--;
            Inv.arrowAmount = molotovAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Molotov ammo left: " + molotovAmmo);//how much ammo is left

        }

        if (molotovAmmo == 0)
            CanThrow = false;
    }

    void ThrowMolotov()
    {
        Debug.Log("Grenade Damage: " + molotovDamage); //prints out how much damage each grenade is doing/going to do

        float angle = Utility.AngleTowardsMouse(Molo.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        ChuckMolotov Chuck = Instantiate(MolotovPrefab, Molo.position, rot).GetComponent<ChuckMolotov>();
        Chuck.MolotovVelocity = molotovSpeed;

        MolotovGFX.enabled = false;
    }
}
