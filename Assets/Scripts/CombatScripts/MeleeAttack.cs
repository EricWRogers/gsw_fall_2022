using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int meleeDamage;
    public AudioManager audio;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKey(KeyCode.Z))
        {
           // Play();
            //Debug.Log("Attack Button Pressed");
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Corruption")) //Checking to see if what we are hitting is corruption or enemies. If so, execute the following.
            {
               // PlayAtk();

                //Debug.Log(collision.gameObject.name);
                Debug.Log("Melee : Hi");
                collision.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(meleeDamage); //Code used to find the enemy's health component and then uses the damage function within to pass in our melee damage.
                //Debug.Log("Hit!");
            }
        }
        /* void Play()
        {
            Debug.Log("No Sound Called");
            AudioSource sound = GameObject.Find("sound_10_swipe").GetComponent<AudioSource>();
            sound.Play();


        }
         void PlayAtk()
        {
            Debug.Log("No Sound Called");
            AudioSource sound = GameObject.Find("sound_4_EnemeyHit").GetComponent<AudioSource>();
            sound.Play();
        } */
    }
}

