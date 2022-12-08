using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSecretMoveScript : MonoBehaviour
{
    Vector2 direction;

    Rigidbody2D rigi;
    public Vector2 joystick;

    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        joystick.x = Input.GetAxisRaw("Horizontal2");
        joystick.y = -Input.GetAxisRaw("Vertical2");

        //if (Vector2.Distance(Vector2.zero, joystick) > 0.01f);
        //{
             transform.position = playerPos.position + ((Vector3) new Vector2(Input.GetAxisRaw("Horizontal2"), -Input.GetAxisRaw("Vertical2")) * 10);
        //}
    
    }
}
