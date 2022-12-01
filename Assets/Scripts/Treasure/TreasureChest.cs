using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour

{
    public bool isOpened;
    public LootTable LT;
    public Sprite newSprite;
    public SpriteRenderer spriteRenderer;
    public Transform lights; 

    public GameObject message;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isOpened == false)
        {
            if (Input.GetKey(KeyCode.X))
            {
                LT.DropItem();
                isOpened = true;
                spriteRenderer.sprite = newSprite;
                Destroy(message);  
                Debug.Log("Chest Opened");
                lights.GetComponent<ParticleSystem>().Play(true);
                
            }
        }

    }

    

}

