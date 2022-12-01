using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject ArrowPrefab;

    [SerializeField] SpriteRenderer ArrowGFX;
    [SerializeField] Slider BowPowerSlider;
    [SerializeField] Transform Bow;
    [SerializeField] float cooldownTime;
    [SerializeField] int bowAmmo;
    public TMP_Text text;

    public Inventory Inv;

    [Range(0, 10)]

    [SerializeField] float BowPower;

    [Range(0, 3)]

    [SerializeField] float MaxBowCharge;

    float BowCharge;
    bool CanFire = true; //can safely remove

    private void Start()
    {
        Inv.arrowAmount = bowAmmo;
        BowPowerSlider.value = 0f;
        BowPowerSlider.maxValue = MaxBowCharge;
    }

    private void Update()
    {

        if (Time.timeScale != 0)
        {
            text.text = "Ammo: " + bowAmmo.ToString(); //for ammo counter, will count down as ammo decreases
            if (Input.GetMouseButton(0) && CanFire)
            {
                ChargeBow();
            }
            else if (Input.GetMouseButtonUp(0) && CanFire)
            {

                FireBow();

                bowAmmo--;
                Inv.arrowAmount = bowAmmo;//ammo in inventory is the ammo count that is used
                Debug.Log("Ammo left: " + bowAmmo);//how much ammo is left
            }
            else
            {
                if (BowCharge > 0f)
                {
                    

                    BowCharge -= cooldownTime * Time.deltaTime;  //0.1f; //how fast the charge goes down before we can fire again
                }
                else
                {
                    BowCharge = 0f;
                    CanFire = true;
                }

                BowPowerSlider.value = BowCharge;
            }


            if (bowAmmo == 0)
                CanFire = false;

        }
    }
        void ChargeBow()
        {
            ArrowGFX.enabled = true;
            BowCharge += Time.deltaTime;
            BowPowerSlider.value = BowCharge;

            if (BowCharge > MaxBowCharge)
            {
                BowPowerSlider.value = MaxBowCharge;
            }
        }

        void FireBow()
        {
            if (BowCharge > MaxBowCharge) BowCharge = MaxBowCharge;

        float ArrowSpeed = BowCharge + BowPower;
            float ArrowDamage = BowCharge * BowPower;
            Debug.Log("Arrow Damage: " + ArrowDamage);

            float angle = Utility.AngleTowardsMouse(Bow.position);
            Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

            Arrow Arrow = Instantiate(ArrowPrefab, Bow.position, rot).GetComponent<Arrow>();
            Arrow.ArrowVelocity = ArrowSpeed;
            Arrow.ArrowDamage = (int)Mathf.Ceil(ArrowDamage);
        CameraShake.Instance.ShakeCamera(5f, .1f);
       
            CanFire = false;
            ArrowGFX.enabled = false;
        }

   
}
