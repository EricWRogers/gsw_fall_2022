using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    public bool isWeaponWheelOpen = false;
    public GameObject weaponWheel;
    // Start is called before the first frame update
    void Start()
    {
        weaponWheel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("WeaponWheelOpen") && isWeaponWheelOpen == false || Input.GetKeyDown(KeyCode.Tab) && isWeaponWheelOpen == false)
        {
            isWeaponWheelOpen = true;
            weaponWheel.SetActive(true);
            Time.timeScale = 0;
        }

        else if(Input.GetButtonDown("WeaponWheelOpen") && isWeaponWheelOpen == true || Input.GetKeyDown(KeyCode.Tab) && isWeaponWheelOpen == true)
        {
            isWeaponWheelOpen = false;
            weaponWheel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}