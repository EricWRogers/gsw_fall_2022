using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public Inventory invin;
    public bool invul = false;
    public int time = 10;



    private void invinc()
    {
        if (invin.currentItem.ToString() == "Invincibility Potion")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                invul = true;
                StartCoroutine(InvulnTime());
                invul = false;
            }

        }
    }
    IEnumerator InvulnTime()
    {
        yield return new WaitForSeconds(time);
    }
      
}
