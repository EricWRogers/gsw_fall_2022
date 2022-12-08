using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBlock : MonoBehaviour

{
    [SerializeField] Transform Shield;
    [SerializeField] Transform Bow;
    public AudioManager audio;

    public Transform target;
    public GameObject hand;

    Quaternion rot;
    
    private void Update()
    {
        Play();


        Vector2 targetPos = target.position;
        Vector2 Direction;
        Direction = targetPos - (Vector2)transform.position;
        hand.transform.right = Direction;
        rot = hand.transform.rotation;//Quaternion.Euler(new Vector3(0f,0f, angle -90f));

        if (Input.GetMouseButton(1) || Input.GetButton("Block") && !Input.GetMouseButton(0))
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
