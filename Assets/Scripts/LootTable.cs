using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public Loot[] loot;
    
    public void DropItem()
    {
        int rand = Random.Range(1, 8);
        Debug.Log("Randum num: " + rand);
       
        foreach (Loot reward in loot)
        {
            if (rand == reward.lootWeight)
            {
                GameObject temp = Instantiate(reward.item, gameObject.transform.position, gameObject.transform.rotation);

                Debug.Log("Item Dropped = " + reward.item.name);
                break;
            }

        }

    }
}
        
    
