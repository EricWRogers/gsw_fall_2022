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

        DisplayLeftBox(1);
        DisplayFarLeftBox(2);
        DisplayRightBox(3);
        DisplayFarRightBox(4);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLeftBox(int index)
    {
        leftBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        leftBox.quanityText.text = inventory.items[index].quanity + "";
        //itemName.text = inventory.items[index].itemStats.itemName;
       // itemDescription.text = inventory.items[index].itemStats.description;
       // damageText.text = inventory.items[index].itemStats.damage + "";
        //attackSpeedText.text = inventory.items[index].itemStats.attackSpeed + "";
    }

    public void DisplayRightBox(int index)
    {
        rightBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        rightBox.quanityText.text = inventory.items[index].quanity + "";
        //itemName.text = inventory.items[index].itemStats.itemName;
       // itemDescription.text = inventory.items[index].itemStats.description;
       // damageText.text = inventory.items[index].itemStats.damage + "";
        //attackSpeedText.text = inventory.items[index].itemStats.attackSpeed + "";
    }

    public void DisplayFarLeftBox(int index)
    {
        farLeftBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        farLeftBox.quanityText.text = inventory.items[index].quanity + "";
        //itemName.text = inventory.items[index].itemStats.itemName;
       // itemDescription.text = inventory.items[index].itemStats.description;
       // damageText.text = inventory.items[index].itemStats.damage + "";
        //attackSpeedText.text = inventory.items[index].itemStats.attackSpeed + "";
    }

        public void DisplayFarRightBox(int index)
    {
        farRightBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        farRightBox.quanityText.text = inventory.items[index].quanity + "";
        //itemName.text = inventory.items[index].itemStats.itemName;
       // itemDescription.text = inventory.items[index].itemStats.description;
       // damageText.text = inventory.items[index].itemStats.damage + "";
        //attackSpeedText.text = inventory.items[index].itemStats.attackSpeed + "";
    }
}
