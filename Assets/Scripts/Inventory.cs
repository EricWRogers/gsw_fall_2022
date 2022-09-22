using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentItem = 0;
    public List<Item> items = new List<Item>();
    public int arrowAmount = 0;
    public int currency = 0;
}

[System.Serializable]
public class Item
{
    public ItemStats itemStats;
    public int quanity;
}