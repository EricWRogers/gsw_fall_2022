using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    
    public Inventory inventory;
    
    public void PickupInv(Item _item)
    {
        foreach(Item item in inventory.items)
            {
                 
                if(item.itemStats is SwordStats && _item.itemStats is SwordStats)
                {
                    SwordStats swordStats = (SwordStats)item.itemStats;
                    if(swordStats.rarity == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                        
                }

        //Display Information if item is a Bow
                if(item.itemStats is BowStats && _item.itemStats is BowStats)
                {
                    BowStats bowStats = (BowStats)item.itemStats;
                    if(bowStats.rarity == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }

        //Display Information if item is a Poison Potion
                if(item.itemStats is PoisonPotionStats && _item.itemStats is PoisonPotionStats)
                {
                    PoisonPotionStats poisonPotionStats = (PoisonPotionStats)item.itemStats;
                    if(poisonPotionStats.rarity == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }

        //Display Information if item is a Health Potion
                if(item.itemStats is HealthPotionStats && _item.itemStats is HealthPotionStats)
                {
                    HealthPotionStats healthPotionStats = (HealthPotionStats)item.itemStats;
                    if(healthPotionStats.rarity == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }

        //Display Information if item is a Combust Potion
                if(item.itemStats is CombustPotionStats && _item.itemStats is CombustPotionStats) 
                {
                    CombustPotionStats combustPotionStats = (CombustPotionStats)item.itemStats;
                    if(combustPotionStats.rarity == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }

        //Display Information if item is a FirePotionStats
                if(item.itemStats is FirePotionStats && _item.itemStats is FirePotionStats)
                {
                    FirePotionStats firePotionStats = (FirePotionStats)item.itemStats;
                    if(firePotionStats.rarity  == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }
                //Display Information if item is a FirePotionStats
                if(item.itemStats is ThrowKnifeStats && _item.itemStats is ThrowKnifeStats)
                {
                    ThrowKnifeStats throwKnifeStats = (ThrowKnifeStats)item.itemStats;
                    if(throwKnifeStats.rarity  == _item.itemStats.rarity)
                    {
                        item.quanity++;
                        return;
                    }
                }
            }

        inventory.items.Add(_item);
    }
}
