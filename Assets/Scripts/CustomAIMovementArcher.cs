using Pathfinding;
using UnityEngine;

public class CustomAIMovementArcher : MonoBehaviour
{
    private Transform target;
    private Transform playerTransform;
    private Transform bowTransform;
    private bool shoot;


    public Transform firingpoint;
    public Transform enemyGFX;
    public GameObject player;
    public GameObject bow;
    public GameObject arrow;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float pathUpdateSpeed = .2f;
    public float AOA = 100; //Area of Awareness
    public bool AOAToggle = false;
    public bool randomizerToggle = false;

    private Vector2 force;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;





    // Start is called before the first frame update
    void Start()
    {
        if (randomizerToggle == true)
        {
            Randomizer();
        }

        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();
        bowTransform = bow.GetComponent<Transform>();

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSpeed);
    }//End of Start

    void FixedUpdate() //Ideal when working with physics
    {

        Ranged();

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }

        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        Flip();

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
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

        if (seeker.IsDone())
        {
            if (distance <= AOA && AOAToggle == true)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
            if (AOAToggle == false)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }// End of UpdatePath

    void OnDrawGizmosSelected() //Drawing AOA
    {
        if (AOAToggle == true)
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

    void Ranged()
    {
        Vector2 targetPos = target.position;
        Vector2 Direction;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D ray = Physics2D.Raycast(bow.transform.position, Direction);
        if (ray.transform.gameObject != null && ray.transform.gameObject.tag == "Player")
        {
            Debug.Log(ray.transform.name);
            bow.transform.up = Direction;
            path = null;

            shoot = true;
        }
        else
        {
            return;
        }
    }

    void Flip()
    {
        if (force.x <= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
            firingpoint.transform.Rotate(new Vector3(0f, 180f, 0f));
        }

        else if (force.x >= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
            firingpoint.transform.Rotate(new Vector3(0f, 180f, 0f));
        }
    }

    public void Shoot()
    {
        if (shoot == true)
        {
            Instantiate(arrow, firingpoint.position, firingpoint.rotation);
        }
    }

}//End of class
