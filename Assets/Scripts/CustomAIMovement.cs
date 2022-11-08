using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomAIMovement : MonoBehaviour
{
    private Transform target;
    private Transform playerTransform;
    public GameObject player;
    private float distance;
    public Invincibility invuln;
    
    public int meleeDamage;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float pathUpdateSpeed = .2f;
    public float AOA = 100; //Area of Awareness
    public bool AOAToggle = false;
    public float attackRange = 10; 
    public bool randomizerToggle = false;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        if(randomizerToggle == true)
        {
            Randomizer();
        }
        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSpeed);
    }//End of Start

    private void Update()
    {
        anim.SetFloat("Direction", rb.velocity.normalized.x);
        anim.SetFloat("Direction", rb.velocity.normalized.y);
    }
    void FixedUpdate() //Ideal when working with physics
    {
        Attack();
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }

        else
        {
            reachedEndOfPath = false;
        }


        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance && currentWaypoint < path.vectorPath.Count -1)
        {
            currentWaypoint++;
        }
    }//End of FixedUpdate
    
     void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }//End of OnPathComplete

    void UpdatePath()
    {
         distance = Vector2.Distance(target.position, transform.position);

        if(seeker.IsDone())
        {
            if(distance <= AOA && AOAToggle == true)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
            if(AOAToggle == false)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }// End of UpdatePath

    void OnDrawGizmosSelected() 
    {
        //Drawing AOA
        if(AOAToggle == true)
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AOA);
        }

       //Drawing melee attackRange
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        
    }

    void Randomizer()
    {
        speed = Random.Range(700f, 800f);
        Debug.Log(speed);
        pathUpdateSpeed = Random.Range(.1f, 1f);
        Debug.Log(pathUpdateSpeed);
    }

    void Attack()
    {
        
        if(distance <= attackRange /*&& !invuln.invul*/)
        {
           target.gameObject.GetComponent<SuperPupSystems.Helper.Health>().Damage(meleeDamage); //Logans Code. Works with Erics Health Script.
           anim.SetTrigger("Attack");
        }
        else
        {
            anim.ResetTrigger("Attack"); //Redundency just in case
            return;
        }
    }

    public void Die()
    {
        anim.SetTrigger("Death");
    }

  
}//End of class
