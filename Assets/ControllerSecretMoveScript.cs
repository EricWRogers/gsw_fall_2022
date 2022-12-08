using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSecretMoveScript : MonoBehaviour
{
    Vector2 direction;
    public float speed;
    private Rigidbody2D rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2")).normalized;

        rigi.velocity = direction * speed;
    }
}
