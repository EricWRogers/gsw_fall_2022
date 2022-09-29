using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    /*public bool aoecheck = false;
    public WeaponScriptableObjects CurrentWeapon;
    public GameObject HitBoxOffset;
    
    //sets the hitbox to true with an input
    public void HitEnemies()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<CircleCollider2D>().enabled = true;
            aoecheck = true;
            Debug.Log("In Hit Function");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(aoecheck) { 
        //checks for contact with the enemy tag
        Debug.Log("In Trigger Function");
        if (collision.gameObject.tag == "Enemy")
        {
            //adjusts health
            collision.gameObject.GetComponent<EnemyHitPoint>().CurrentHP -= CurrentWeapon.WeaponDamage;

            //weapon will break
            CurrentWeapon.WeaponDurability -= 1;
            if (CurrentWeapon.WeaponDurability <= 0)
                Debug.Log("Weapon Broke");

            //enemy will be removed if health is gone
            if (collision.gameObject.GetComponent<EnemyHitPoint>().CurrentHP <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        //hitbox is set back to false
        aoecheck = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    
    //running to be able to turn hitbox on
    void Update()
    {
        HitEnemies();

    }
}*/
    public int meleeDamage;


    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.Z))
        {

            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(meleeDamage);
                Debug.Log("Hit!");
            }
        }
    }

}

