using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.Z))
        {
            //Debug.Log("Attack Button Pressed");
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Corruption")) //Checking to see if what we are hitting is corruption or enemies. If so, execute the following.
            {
                //Debug.Log(collision.gameObject.name);
                Debug.Log("Melee : Hi");
                collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(meleeDamage); //Code used to find the enemy's health component and then uses the damage function within to pass in our melee damage.
                //Debug.Log("Hit!");
            }
        }
    }

}

