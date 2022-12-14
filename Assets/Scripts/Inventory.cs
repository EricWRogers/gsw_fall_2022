using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentItem = 0;
    public List<Item> items = new List<Item>();
    public int arrowAmount = 0;
    public int currency = 0;

    private void Update()
    {
        if(items[currentItem].quanity <= 0)
        {
            items.Remove(items[currentItem]); //When we run out of the item, remove it
        }
    }
}

[System.Serializable]
public class Item
{
    public ItemStats itemStats;
    public int quanity;
    public int rarity;

    void Awake()
    {
        rarity = itemStats.rarity;
    }
}