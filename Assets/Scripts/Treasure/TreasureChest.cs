using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour

{
    private bool isOpened;
    
    public GameObject[] lootTable;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                DropItem();
                isOpened = true;
            }
        }

    }

    public void DropItem()
    {
        float weight = Random.Range(0f, 10f);

        if (weight >= 1 && weight <= 4)
        {
            GameObject temp = Instantiate(lootTable[0], gameObject.transform.position, gameObject.transform.rotation);
        }

        if (weight >= 4 && weight <= 6)
        {
            GameObject temp = Instantiate(lootTable[1], gameObject.transform.position, gameObject.transform.rotation);
        }

        if (weight >= 6 && weight <= 10)
        {
            GameObject temp = Instantiate(lootTable[2], gameObject.transform.position, gameObject.transform.rotation);
        }

    }

}

