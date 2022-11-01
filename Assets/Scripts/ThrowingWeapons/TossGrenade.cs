using System.Collections.Generic;
using UnityEngine;


public class TossGrenade : MonoBehaviour
{

   
    [SerializeField] Rigidbody2D rb;
    public GrenadeManager GN;
    public GameObject player;


    public float delay = 2f; //how long before the grenade explodes
    public float countDown;

    public float force, radius;

    [HideInInspector] public float GrenadeVelocity;
    private void Start()
    {
        GN = player.GetComponent<GrenadeManager>();
        countDown = delay;

        rb.velocity = transform.up * GrenadeVelocity;
    }
    private void FixedUpdate()
    {
        //Destroy(gameObject, 2f);  //how long the objects stay in the scene before getting deleted if they don't hit anything
        //in this case 2 seconds before they disappear

    }
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0f)
        {
            Explode();

        }
    }

    public void Explode()
    {

        //show visual effects
        //Instantiate(explosionEffect, transform.position, transform.rotation);

        //get nearby objects
        Vector2 origin = transform.position;


        //adds the force to each collider in the radius, therefore pushing them back

        foreach (Collider2D nearbyObject in Physics2D.OverlapCircleAll(origin, radius))
        {
           if(nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>() != null)
            {
                nearbyObject.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(1 - new Vector2(nearbyObject.transform.position - gameObject.transform.position).magnitude * GN.grenadeDamage); 
                //^ deals damage to every nearby object.
                //^ CS7036: There is no argument given that corresponds to the required formal parameter 'y' of 'Vector2.Vector2(float,float)'
                Debug.Log(nearbyObject);
                //add force, pushes stuff away if they have a rigidbody
                Rigidbody2D rb = nearbyObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.AddForce((transform.position.x, transform.position.y).magnitude);
                    //obviously gonna have to be edited to fit the force stuff
                    //Error CS1061  '(float x, float y)' does not contain a definition for 'magnitude' and no accessible extension method 'magnitude' accepting a first argument of type '(float x, float y)' could be found(are you missing a using directive or an assembly reference ?)
                }
            }
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
