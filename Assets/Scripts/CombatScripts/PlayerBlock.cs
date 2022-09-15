using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    [SerializeField] Transform Shield;
    [SerializeField] Transform Bow;   
    
    private void Update()
    {
        if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
        {
            StartBlock();
        }
        else
        {
            Shield.gameObject.SetActive(false);
            Bow.gameObject.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().walkSpeed = 10;
        }
        
        
    }

    void StartBlock()
    {
        float angle = Utility.AngleTowardsMouse(Shield.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Bow.gameObject.SetActive(false);
        Shield.gameObject.SetActive(true);

        gameObject.GetComponent<PlayerMovement>().walkSpeed = 5;
    }
}