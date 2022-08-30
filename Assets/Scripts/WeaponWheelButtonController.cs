using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelButtonController : MonoBehaviour
{
    public int ID;
    public string itemName;
    public TextMeshProUGUI itemText;
    public Image selectedItem;
    private bool selected = false;
    public Sprite icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
        WeaponWheelController.weaponID = ID;
    }

    public void Deselected()
    {
        selected = false;
        WeaponWheelController.weaponID = 0;
    }

    public void HoverEnter()
    {
        itemText.text = itemName;
    }

    public void HoverExit()
    {
        itemText.text = "";
    }
}
