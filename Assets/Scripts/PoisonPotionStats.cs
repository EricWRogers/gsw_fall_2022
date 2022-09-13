using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poison Potion", menuName = "Items/Poison Potion")]
public class PoisonPotionStats : ItemStats
{
    public int damage;
    public int duration;
    public int range;
    public int areaOfEffect;
}
