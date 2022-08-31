using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float interval = 100f;
    public bool toggle = false;
    public int currentEnemies = 0;
    public int wave = 0;
    private int spawned;
    

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    

   public void SpawnEnemy()
    {
        
        if(toggle == true && currentEnemies != spawned)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            spawned++;
        }
        if(currentEnemies == 0)
        {
            spawned = 0;
            wave++;

            currentEnemies = wave * 3;
        }
       
    }
}
