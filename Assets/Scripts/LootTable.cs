using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public Loot[] loot;
    
    public void DropItem()
    {
        foreach (Loot l in loot)
        {
            
            float rand = Random.Range(0f, 10f);
            Debug.Log("Randum num: " + rand);

            if (rand < l.lootWeight)
            {

                GameObject temp = Instantiate(l.item, gameObject.transform.position, gameObject.transform.rotation);

                Debug.Log("Item Dropped");
                break;
            }

        }

    }
}
        
    
