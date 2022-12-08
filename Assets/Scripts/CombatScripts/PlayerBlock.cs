using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBlock : MonoBehaviour

{
    [SerializeField] Transform Shield;
    [SerializeField] Transform Bow;
    public AudioManager audio;

    
    private void Update()
    {
        Play();

        if (Input.GetMouseButton(1) || Input.GetButton(KeyCode.Joystick1Button4.ToString()) && !Input.GetMouseButton(0))
        {

            StartBlock();
            Play();

        }
        else
        {
            Shield.gameObject.SetActive(false);
            Bow.gameObject.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().walkSpeed = 10;
        }
        
        
    }

    void StartBlock()
    {
        
        float angle = Utility.AngleTowardsMouse(Shield.position);
        Quaternion rot = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));

        Bow.gameObject.SetActive(false);
        Shield.gameObject.SetActive(true);

        gameObject.GetComponent<PlayerMovement>().walkSpeed = 5;
    }
    private void Play()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            AudioSource sound = GameObject.Find("sound_16_Block").GetComponent<AudioSource>();
            sound.Play();

        }
        else
        {
            return;
        }
    }
    }
