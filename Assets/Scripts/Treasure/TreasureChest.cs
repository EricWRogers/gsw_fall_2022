using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour

{
    public bool isOpened;
    public LootTable LT;
    
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpened == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                LT.DropItem();
                isOpened = true;
                Debug.Log("Chest Opened");
            }
        }

    }

    

}

