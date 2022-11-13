using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeaponManager : MonoBehaviour
{
    public Inventory Inv;
    public bool canFire;
    public bool canThrow;
    public TMP_Text ammoText;

    [SerializeField] Transform hand;
    #region BowDeclarations

    [SerializeField] GameObject ArrowPrefab;

    [SerializeField] SpriteRenderer ArrowGFX;
    [SerializeField] Slider BowPowerSlider;
    
    [SerializeField] float cooldownTime;
    [SerializeField] int bowAmmo;
    

   

    [Range(0, 10)]

    [SerializeField] float BowPower;

    [Range(0, 3)]

    [SerializeField] float MaxBowCharge;

    float BowCharge;
    

    #endregion

    #region GrenadeDeclarations
    //public float radius = 4f; // how large the explosion is
    //public float force = 250f;
    public float grenadeSpeed;
    public float grenadeDamage;
    public int grenadeAmmo;

    public GameObject GrenadePrefab;
 

    //public SpriteRenderer explosionEffect;
    public SpriteRenderer GrenadeGFX;


    
  
    
    #endregion

    #region ThrowingKnifeDeclarations
    [SerializeField] GameObject ThrowingKnifePrefab;
    public int knifeDamage;
    [SerializeField] int knifeAmmo;
    [SerializeField] SpriteRenderer KnifeGFX;
   
    [SerializeField] float KnifeSpeed;


    #endregion

    void Start()
    {
        //Bow
        Inv.arrowAmount = bowAmmo;
        BowPowerSlider.value = 0f;
        BowPowerSlider.maxValue = MaxBowCharge;

        //Grenade
        Inv.arrowAmount = grenadeAmmo;

        Inv.arrowAmount = knifeAmmo;
    }


    void Update()
    {
        string name = Inv.items[Inv.currentItem].itemStats.name;

        if (name == "CommonBow") 
        {
            Debug.Log("Current Weapon = " + name);
            
            BowShoot();
        }

        if (name == "MediumCombustPotion")
        {
            Debug.Log("Current Weapon = " + name);
           
            GrenadeThrow();
        }

        if (name == "ThrowingKnife")
        {
            Debug.Log("Current Weapon = " + name);
          
            KnifeThrow();
        }

    }

    #region BowFunctions
    void BowShoot()
    {
        if (Time.timeScale != 0)
        {
            ammoText.text = "Ammo: " + bowAmmo.ToString(); //for ammo counter, will count down as ammo decreases
            if (Input.GetMouseButton(0) && canFire)
            {
                ChargeBow();
            }
            else if (Input.GetMouseButtonUp(0) && canFire)
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
                    canFire = true;
                }

                BowPowerSlider.value = BowCharge;
            }


            if (bowAmmo == 0)
                canFire = false;
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

        float angle = Utility.AngleTowardsMouse(hand.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Arrow Arrow = Instantiate(ArrowPrefab, hand.position, rot).GetComponent<Arrow>();
        Arrow.ArrowVelocity = ArrowSpeed;
        Arrow.ArrowDamage = (int)Mathf.Ceil(ArrowDamage);

        canFire = false;
        ArrowGFX.enabled = false;
    }
    #endregion

    #region GrenadeFunctions
    void GrenadeThrow()
    {
        ammoText.text = "Ammo: " + grenadeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            ThrowGrenade();
            grenadeAmmo--;
            Inv.arrowAmount = grenadeAmmo;//ammo in inventory is the ammo count that is used
            Debug.Log("Grenade ammo left: " + grenadeAmmo);//how much ammo is left

        }

        if (grenadeAmmo == 0)
            canThrow = false;
    }

    void ThrowGrenade()
    {
        Debug.Log("Grenade Damage: " + grenadeDamage); //prints out how much damage each grenade is doing/going to do

        float angle = Utility.AngleTowardsMouse(hand.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        TossGrenade Toss = Instantiate(GrenadePrefab, hand.position, rot).GetComponent<TossGrenade>();

        Toss.GrenadeVelocity = grenadeSpeed;

        GrenadeGFX.enabled = false;
    }
    #endregion

    #region KnifeFunctions
    void ThrowKnife()
    {
        Debug.Log("Knife Damage: " + knifeDamage); //prints out how much damage each knife is doing/going to do

        float angle = Utility.AngleTowardsMouse(hand.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Throw Throw = Instantiate(ThrowingKnifePrefab, hand.position, rot).GetComponent<Throw>();
        knifeDamage = (int)Mathf.Ceil(knifeDamage);

        Throw.KnifeVelocity = KnifeSpeed;

        //CanThrow = false; //don't uncomment
        KnifeGFX.enabled = false;
    }

    void KnifeThrow()
    {
        if (Time.timeScale != 0)
        {

            ammoText.text = "Ammo: " + knifeAmmo.ToString(); //for ammo counter, will count down as ammo decreases
            if (Input.GetMouseButtonDown(0) && canThrow)
            {
                ThrowKnife();
                knifeAmmo--;
                Inv.arrowAmount = knifeAmmo;//ammo in inventory is the ammo count that is used
                Debug.Log("Knife ammo left: " + knifeAmmo);//how much ammo is left
            }

            if (knifeAmmo == 0)
                canThrow = false;
        }
    }
    #endregion


}
