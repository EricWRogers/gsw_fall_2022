using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Trading : MonoBehaviour
{

    public ItemHolder middleBox;
    public ItemHolder leftBox;
    public ItemHolder rightBox;

    public Image leftArrow;
    public Image rightArrow;

    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text statsText;
    public TMP_Text costText;

    public Inventory inventory;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for if the right or left bumper is pushed to cycle through the inventory menu.
        if(Input.GetButtonDown("WindowsLeftBumper") || Input.GetKeyDown(KeyCode.A))
        {
            inventory.currentItem --;
        }
        if(Input.GetButtonDown("WindowsRightBumper") || Input.GetKeyDown(KeyCode.D))
        {
            inventory.currentItem ++;
        }

        inventory.currentItem = Mathf.Clamp(inventory.currentItem, 0, inventory.items.Count - 1);

        UpdateWeaponWheel(inventory.currentItem);
    }

    public void UpdateWeaponWheel(int index)
    {
        if (inventory.items.Count == 0)
        {
            Debug.LogError("inventory empty");
        }

        index = Mathf.Clamp(index, 0, inventory.items.Count - 1);

        int leftBoxIndex = index - 1;
        int middleBoxIndex = index;
        int rightBoxIndex = index + 1;


        //Checks to see if the the arrows showing more items are in the inventory need to be displayed or not.
        if(index - 2 > -1)
        {
            leftArrow.enabled = true;
        }
        else
        {
            leftArrow.enabled = false;
        }
        if(index + 2 < inventory.items.Count)
        {
            rightArrow.enabled = true;
        }
        else
        {
            rightArrow.enabled = false;
        }
        

        if(leftBoxIndex > -1)
        {
            leftBox.itemholder.SetActive(true);
            DisplayLeftBox(leftBoxIndex);
        }
        else{
            leftBox.itemholder.SetActive(false);
        }
        
        if(-1 < index && index < inventory.items.Count)
        {
            middleBox.itemholder.SetActive(true);
            DisplayMiddleBox(middleBoxIndex);
        }
        else{
            middleBox.itemholder.SetActive(false);
        }


        if(rightBoxIndex < inventory.items.Count)
        {
            rightBox.itemholder.SetActive(true);
            DisplayRightBox(rightBoxIndex);
        }
        else{
            rightBox.itemholder.SetActive(false);
        }

    }

    public void DisplayMiddleBox(int index)
    {
        middleBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        costText.text = "Cost: " + inventory.items[index].itemStats.cost;
        if(inventory.items[index].quanity > 1)
        {
            middleBox.quanityText.gameObject.SetActive(true);
            middleBox.quanityBox.gameObject.SetActive(true);
            middleBox.quanityText.text = inventory.items[index].quanity + "";
        }
        else
        {
            middleBox.quanityText.gameObject.SetActive(false);
            middleBox.quanityBox.gameObject.SetActive(false);
        }


        itemName.text = inventory.items[index].itemStats.itemName;
        itemDescription.text = inventory.items[index].itemStats.description;

        // clear stuff
        statsText.text = "";

        //Display Information if item is a Sword
        if(inventory.items[index].itemStats is SwordStats)
        {
            SwordStats swordStats = (SwordStats)inventory.items[index].itemStats;
            statsText.text = "Damage: " + swordStats.damage + " | Attack Speed: " + swordStats.attackSpeed;
        }

        //Display Information if item is a Bow
        if(inventory.items[index].itemStats is BowStats)
        {
            BowStats bowStats = (BowStats)inventory.items[index].itemStats;
            statsText.text = "Damage: " + bowStats.damage + " | Fire Rate: " + bowStats.fireRate + " | Cooldown: " + bowStats.coolDown + " | Range: " + bowStats.range;
        }

        //Display Information if item is a Poison Potion
        if(inventory.items[index].itemStats is PoisonPotionStats)
        {
            PoisonPotionStats poisonPotionStats = (PoisonPotionStats)inventory.items[index].itemStats;
            statsText.text = "Damage: " + poisonPotionStats.damage + " | Duration: " + poisonPotionStats.duration + " | AOE: " + poisonPotionStats.areaOfEffect + " | Range: " + poisonPotionStats.range;
        }

        //Display Information if item is a Health Potion
        if(inventory.items[index].itemStats is HealthPotionStats)
        {
            HealthPotionStats healthPotionStats = (HealthPotionStats)inventory.items[index].itemStats;
            statsText.text = "Health: " + healthPotionStats.healthAdded + " | Duration: " + healthPotionStats.duration;
        }

        //Display Information if item is a Combust Potion
        if(inventory.items[index].itemStats is CombustPotionStats)
        {
            CombustPotionStats combustPotionStats = (CombustPotionStats)inventory.items[index].itemStats;
            statsText.text = "Damage: " + combustPotionStats.damage + " | AOE: " + combustPotionStats.areaOfEffect + " | Range: " + combustPotionStats.range ;
        }

        //Display Information if item is a FirePotionStats
        if(inventory.items[index].itemStats is FirePotionStats)
        {
            FirePotionStats firePotionStats = (FirePotionStats)inventory.items[index].itemStats;
            statsText.text = "Damage: " + firePotionStats.damage + " | Durartion: " + firePotionStats.duration + " | Strength: " + firePotionStats.strength + " | Range: " + firePotionStats.range + " | Fire Spread: " + firePotionStats.fireSpread;
        }

    }

    public void DisplayLeftBox(int index)
    {
        leftBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        leftBox.quanityText.text = inventory.items[index].quanity + "";
        if(inventory.items[index].quanity > 1)
        {
            leftBox.quanityText.gameObject.SetActive(true);
            leftBox.quanityBox.gameObject.SetActive(true);
            leftBox.quanityText.text = inventory.items[index].quanity + "";
        }
        else
        {
            leftBox.quanityText.gameObject.SetActive(false);
            leftBox.quanityBox.gameObject.SetActive(false);
        }
    }

    public void DisplayRightBox(int index)
    {
        rightBox.itemIcon.sprite = inventory.items[index].itemStats.icon;
        rightBox.quanityText.text = inventory.items[index].quanity + "";
        if(inventory.items[index].quanity > 1)
        {
            rightBox.quanityText.gameObject.SetActive(true);
            rightBox.quanityBox.gameObject.SetActive(true);
            rightBox.quanityText.text = inventory.items[index].quanity + "";
        }
        else
        {
            rightBox.quanityText.gameObject.SetActive(false);
            rightBox.quanityBox.gameObject.SetActive(false);
        }
    }

    
}
