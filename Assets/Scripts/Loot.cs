using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot 
{
    public GameObject item;
    [Tooltip("Higher number means it is more likely to spawn.")]
    [Range(0, 10)]
    public int lootWeight;
}
