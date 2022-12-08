using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAim : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        Vector2 Direction;
        Direction = targetPos - (Vector2)transform.position;
        gameObject.transform.up = Direction;
    }
}
