using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingHud : MonoBehaviour
{
    public bool isTradingHudOpen = false;
    public HudScript hud;
    public GameObject tradingHud;
    private bool isMerchant = false;
    // Start is called before the first frame update
    void Start()
    {
        tradingHud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("TradingHudOpen") && isTradingHudOpen == false &&  hud.isWeaponWheelOpen == false && isMerchant == true || Input.GetKeyDown(KeyCode.Q) && isTradingHudOpen == false &&  hud.isWeaponWheelOpen == false && isMerchant == true)
        {
            isTradingHudOpen = true;
            tradingHud.SetActive(true);
            Time.timeScale = 0;
        }

        else if(Input.GetButtonDown("TradingHudOpen") && isTradingHudOpen == true || Input.GetKeyDown(KeyCode.Q) && isTradingHudOpen == true)
        {
            isTradingHudOpen = false;
            tradingHud.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Merchant");
        isMerchant = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("Left Merchant");
        isMerchant = false;
    }
}
