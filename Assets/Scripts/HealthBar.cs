using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperPupSystems.Helper;

public class HealthBar : Health
{
    public Slider HealthSlider;

    // Update is called once per frame
    void Update()
    {
        HealthSlider.value = gameObject.GetComponent<SuperPupSystems.Helper.Health>().CurrentHealth; ;
    }
}
