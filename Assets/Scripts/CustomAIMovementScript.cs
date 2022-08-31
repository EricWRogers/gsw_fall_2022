using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomAIMovementScript : MonoBehaviour
{
    private Transform target;
    private Transform playerTransform;
    public GameObject player;
    
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float pathUpdateSpeed = .2f;
    public float AOA = 100; //Area of Awareness
    public bool AOAToggle = false;
    public bool randomizerToggle = false;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;



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

    void FixedUpdate() //Ideal when working with physics
    {
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

        if(distance < nextWaypointDistance)
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
        float distance = Vector2.Distance(target.position, transform.position);

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

    void OnDrawGizmosSelected() //Drawing AOA
    {
        if(AOAToggle == true)
        {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AOA);
        }
    }

    void Randomizer()
    {
        speed = Random.Range(700f, 800f);
        Debug.Log(speed);
        pathUpdateSpeed = Random.Range(.1f, 1f);
        Debug.Log(pathUpdateSpeed);
    }
}//End of class
