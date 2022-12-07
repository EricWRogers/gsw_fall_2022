using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWeaponManager : MonoBehaviour
{
    public Inventory Inv;
    public bool canFire;
    public bool canThrow;
    public TMP_Text ammoText;
    public AudioManager audio;

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

    #region MolotovDeclarations
    public float molotovSpeed;
    public int molotovDamage;
    public int molotovAmmo;

    public GameObject MolotovPrefab;

    public SpriteRenderer MolotovGFX;
    #endregion

    void Start()
    {

        BowPowerSlider.value = 0f;
        BowPowerSlider.maxValue = MaxBowCharge;
        
        Inv.arrowAmount = molotovAmmo;

    }


    void Update()
    {
        string name = Inv.items[Inv.currentItem].itemStats.name;

        if (name == "CommonSword")
        {
            Transform temp = gameObject.transform.Find("Hand/MoonSword");
            temp.gameObject.SetActive(true);
           

            CommonSword();
        }
        if (name != "CommonSword")
        {
            Transform temp = gameObject.transform.Find("Hand/MoonSword");
            temp.gameObject.SetActive(false);
        }

        if (name == "CommonBow")
        {
            Inv.items[Inv.currentItem].quanity = bowAmmo;
            //Debug.Log("Current Weapon = " + name);

            BowShoot();

        }
        if (name == "MediumCombustPotion")
        {
            Transform temp = gameObject.transform.Find("Hand/GrenPos");
            temp.gameObject.SetActive(true);

            
            Inv.items[Inv.currentItem].quanity = grenadeAmmo;
            //Debug.Log("Current Weapon = " + name);

            GrenadeThrow();
        }
        if (grenadeAmmo <= 0 || name != "MediumCombustPotion")
        {
            Transform temp = gameObject.transform.Find("Hand/GrenPos");
            temp.gameObject.SetActive(false);
        }
        if (name == "ThrowingKnife")
        {
            Transform temp = gameObject.transform.Find("Hand/KnifePos");
            temp.gameObject.SetActive(true);

            
            Inv.items[Inv.currentItem].quanity = knifeAmmo;
            //Debug.Log("Current Weapon = " + name);

            KnifeThrow();
        }
        if (knifeAmmo <= 0 || name != "ThrowingKnife")
        {
            Transform temp = gameObject.transform.Find("Hand/KnifePos");
            temp.gameObject.SetActive(false);
        }

        if (name == "SmallFirePotion")
        {
            Transform temp = gameObject.transform.Find("Hand/MolotovPos");
            temp.gameObject.SetActive(true);

            
            Inv.items[Inv.currentItem].quanity = molotovAmmo;
            //Debug.Log("Current Weapon = " + name);


            ammoText.text = "Ammo: " + molotovAmmo.ToString(); //for ammo counter, will count down as ammo decreases
            if (Input.GetMouseButtonDown(0) && canThrow)
            {
                ThrowMolotov();
                molotovAmmo--;
                Inv.arrowAmount = molotovAmmo;//ammo in inventory is the ammo count that is used
                Debug.Log("Molotov ammo left: " + molotovAmmo);//how much ammo is left

            }

            if (molotovAmmo == 0)
                canThrow = false;
        }
        if (molotovAmmo <= 0 || name != "SmallFirePotion")
        {
            Transform temp = gameObject.transform.Find("Hand/MolotovPos");
            temp.gameObject.SetActive(false);
        }

        if(name == "SmallHealthPotion")
        {
            Transform temp = gameObject.transform.Find("Hand/potion");
            temp.gameObject.SetActive(true);
            Healing(10);
        }
        if(name != "SmallHealthPotion")
        {
            Transform temp = gameObject.transform.Find("Hand/potion");
            temp.gameObject.SetActive(false);
        }

    }

    #region BowFunctions
    void BowShoot()
    {
        PlayDraw();
        Play();
        if (Time.timeScale != 0)
        {
            ammoText.text = "Ammo: " + bowAmmo.ToString(); //for ammo counter, will count down as ammo decreases
            if (Input.GetMouseButton(0) && canFire)
            {
                
                Transform temp = gameObject.transform.Find("Hand/BowPos2");
                temp.gameObject.SetActive(true);
                ChargeBow();
            }
            else if (Input.GetMouseButtonUp(0) && canFire)
            {
                Transform temp = gameObject.transform.Find("Hand/BowPos2");
                temp.gameObject.SetActive(false);

                FireBow();
                bowAmmo--;
                Inv.arrowAmount = bowAmmo;//ammo in inventory is the ammo count that is used
                //Debug.Log("Ammo left: " + bowAmmo);//how much ammo is left
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
        //Debug.Log("Arrow Damage: " + ArrowDamage);

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

    #region MolotovFunctions
    void ThrowMolotov()
    {
        Debug.Log("Molotov Damage: " + molotovDamage); //prints out how much damage each grenade is doing/going to do

        float angle = Utility.AngleTowardsMouse(hand.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        ChuckMolotov Chuck = Instantiate(MolotovPrefab, hand.position, rot).GetComponent<ChuckMolotov>();
        Chuck.MolotovVelocity = molotovSpeed;

        MolotovGFX.enabled = false;
    }
    #endregion

    void CommonSword()
    {
        float angle = Utility.AngleTowardsMouse(hand.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }

    private void Play()
    {


        if (Input.GetMouseButtonUp(0))
        { 
            AudioSource sound = GameObject.Find("sound_11_Bow Fire").GetComponent<AudioSource>();
            sound.Play();
            Debug.Log("Why no Play Fire?");
        }
        else
        {
            return;
        }
    }
    private void PlayDraw()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource sound = GameObject.Find("sound_12_Bow Draw").GetComponent<AudioSource>();
            sound.Play();
            Debug.Log("Why no Play Fire?");
        }
        else
        {
            return;
        }
    }

    public void Healing(int _amount)
    {
        if(Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<SuperPupSystems.Helper.Health>().Heal(_amount);
            Inv.items[Inv.currentItem].quanity -= 1;
        }
    }
}
