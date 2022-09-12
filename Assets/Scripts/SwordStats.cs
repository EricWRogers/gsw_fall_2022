using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sword", menuName = "Items/Sword")]
public class SwordStats : ItemStats
{
    public int damage;
    public int attackSpeed;
}
