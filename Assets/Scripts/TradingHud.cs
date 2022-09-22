using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingHud : MonoBehaviour
{
    public bool isTradingHudOpen = false;
    public GameObject tradingHud;
    // Start is called before the first frame update
    void Start()
    {
        tradingHud.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("TradingHudOpen") && isTradingHudOpen == false || Input.GetKeyDown(KeyCode.Q) && isTradingHudOpen == false)
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
}
