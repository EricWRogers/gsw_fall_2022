using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheel : MonoBehaviour
{
    public ItemHolder middleBox;
    public ItemHolder leftBox;
    public ItemHolder farLeftBox;
    public ItemHolder rightBox;
    public ItemHolder farRightBox;

    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text damageText;
    public TMP_Text attackSpeedText;

    public Inventory inventory;

    public int index;


    // Start is called before the first frame update
    void Start()
    {
        middleBox.itemIcon.sprite = inventory.items[inventory.currentItem].itemStats.icon;
        middleBox.quanityText.text = inventory.items[inventory.currentItem].quanity + "";
        itemName.text = inventory.items[inventory.currentItem].itemStats.itemName;
        itemDescription.text = inventory.items[inventory.currentItem].itemStats.description;
        damageText.text = inventory.items[inventory.currentItem].itemStats.damage + "";
        attackSpeedText.text = inventory.items[inventory.currentItem].itemStats.attackSpeed + "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
