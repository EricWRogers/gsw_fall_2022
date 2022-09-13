using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fire Potion", menuName = "Items/Fire Potion")]
public class FirePotionStats : ItemStats
{
    public int damage;
    public int range;
    public int duration;
    public int strength;
    public int fireSpread;
}
