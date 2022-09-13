using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Items/Bow")]
public class BowStats : ItemStats
{
    public int damage;
    public int fireRate;
    public int coolDown;
    public int range;
}
