using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "WeaponPreset",  menuName = "WeaponObject", order = 0)]
public class WeaponScriptableObjects : ScriptableObject
{
    public int WeaponDamage;
    public int WeaponDurability;
    public GameObject HitBox;
}
