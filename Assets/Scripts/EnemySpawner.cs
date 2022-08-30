using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Transform spawner;
    public GameObject enemyPrefab;

    public float interval = 100f;
    public bool toggle = false;
    public int limit = 0;
    public int wave = 0;
    private int spawned;
    

    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    

   public void SpawnEnemy()
    {
        
        if(toggle == true && limit != spawned)
        {
             Instantiate(enemyPrefab, spawner);
             spawned++;
             
        }
        if(limit == 0)
        {
            spawned = 0;
            wave++;

            limit = wave * 3;
        }
       
    }
}
