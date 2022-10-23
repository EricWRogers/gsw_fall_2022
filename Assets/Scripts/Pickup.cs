using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    private Inventory INVIN;
    void Start()
    {
        INVIN = GameObject.Find("Inventory").GetComponent<Inventory>(); //Finds inventory gameOBJ and gets script component and sets it equals to INVIN
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickupSystem>())
        {

            Debug.Log("HELP");
            collision.gameObject.GetComponent<PickupSystem>().PickupInv(item);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Arrow")) //Checks to see if we are colliding with arrows.
        {
            INVIN.arrowAmount += 1; //Adds one to the arrows.
        }

        if (collision.gameObject.CompareTag("ArrowBundle")) //Checks to see if we are colliding with arrows.
        {
            INVIN.arrowAmount += 3; //Adds one to the arrows.
        }


    }

    

}

