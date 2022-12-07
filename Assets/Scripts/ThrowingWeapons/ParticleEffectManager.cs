using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    public GameObject deathPFX;
    public GameObject damagePFX;



    /*public void initilizeEffect()
    {
        if (deathPFX == null)
        {
            damagePFX = this.gameObject.GetComponent<ParticleSystem>();
            deathPFX = this.gameObject.GetComponent<ParticleSystem>();
        }
    }*/
    public void playDeathPFX()
    {
        Instantiate(deathPFX, transform.position, transform.rotation);
       //deathPFX.Play();
    }

    public void playDamagePFX()
    {
        Instantiate(damagePFX, transform.position, transform.rotation);
        //damagePFX.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        //damagePFX = this.gameObject.GetComponent<ParticleSystem>();
        //deathPFX = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
