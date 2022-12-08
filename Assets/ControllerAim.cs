using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAim : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    // Update is called once per frame
    void Update()
    {
        // timeCounter += Time.deltaTime;
        speed = Input.GetAxis("RightStick") * 100;
        transform.RotateAround(GameObject.Find("Hand").transform.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
    }
}
