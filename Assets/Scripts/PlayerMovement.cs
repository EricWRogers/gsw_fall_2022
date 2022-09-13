using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    public float stamina = 100f;
    public float staminaDepleteTime;
    public float staminaRegenTime;

    public bool sprinting = false;
    public bool resting = false;

    public float movementSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    Vector2 direction;

    //bow and arrow controls
    [SerializeField] Transform hand;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get direction of input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        sprinting = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("debug");
            if (resting == false)
            {
                stamina -= Time.deltaTime * staminaDepleteTime;
                sprinting = true;
                if (stamina <= 0)
                {
                    resting = true;
                }
            }

            if (resting == true)
            {
                sprinting = false;
                if (stamina >= 100)
                {
                    resting = false;
                }
            }






        }
        
        
            if (stamina < 100 && !sprinting)
            {
                stamina += Time.deltaTime * staminaRegenTime;
            }
        

        //stamina = Mathf.Clamp01(stamina);

        if (sprinting)
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = walkSpeed;
        }

        if (resting)
        {
            if (stamina < 100)
            {
                sprinting = false;
            }
            else
            {
                resting = false;
            }
        }



        //set walk based on direction
        body.velocity = direction * movementSpeed;

        //bow and arrow control
        RotateHand();
    }

    //bow and arrow control
    void RotateHand()
    {
        float angle = Utility.AngleTowardsMouse(hand.position);
        hand.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
