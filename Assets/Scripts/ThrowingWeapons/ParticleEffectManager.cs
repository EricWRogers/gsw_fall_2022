using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
{
    private ParticleSystem deathPFX;
    private ParticleSystem damagePFX;



    public void initilizeEffect()
    {
        if (deathPFX == null)
        {
            damagePFX = this.gameObject.GetComponent<ParticleSystem>();
            deathPFX = this.gameObject.GetComponent<ParticleSystem>();
        }
    }
    public void playDeathPFX()
    {
        deathPFX.Play();
    }

    public void playDamagePFX()
    {
        damagePFX.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
