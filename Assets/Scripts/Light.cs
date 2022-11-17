using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    
    public GameObject happyLight;
    public GameObject sadLight;

    public void HappyLight()
    {
        happyLight.SetActive(true);
        sadLight.SetActive(false);
    }

    public void SadLight()
    {
        happyLight.SetActive(false);
        sadLight.SetActive(true);
    }
}
