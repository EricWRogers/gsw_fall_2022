using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    public Item testItem;




    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickupSystem>())
        {

            Debug.Log("HELP");
            collision.gameObject.GetComponent<PickupSystem>().PickupInv(testItem);
            Destroy(gameObject);
        }
    }

    

}

