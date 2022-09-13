using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemStats : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int rarity;
    public int cost;

}

