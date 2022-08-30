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

    private int spawned;
    

    // Start is called before the first frame update
    void Start()
    {
        spawner = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; limit >= spawned; spawned++)
        {
            InvokeRepeating("SpawnEnemy", 5f, interval);
            
            Debug.Log(spawned);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawner);
    }
}
