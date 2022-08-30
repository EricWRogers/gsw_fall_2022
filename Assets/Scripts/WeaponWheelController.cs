using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWheelController : MonoBehaviour
{
    private bool weaponWheelSelected = false;
    public Image selectedItem;
    public Sprite noImage;
    public static int weaponID;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            weaponWheelSelected = !weaponWheelSelected;
        }


        switch(weaponID)
        {
            case 0: //Nothing is Selected
                selectedItem.sprite = noImage;
                break;
            case 1: //Diamond
                Debug.Log("Diamond");
                break;
            case 2: //Hex
                Debug.Log("Hex");
                break;
            case 3: //Square
                Debug.Log("Square");
                break;
            case 4: //Capsule
                Debug.Log("Cap");
                break;

        }
    }
}
