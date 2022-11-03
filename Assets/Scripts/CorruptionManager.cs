using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionManager : MonoBehaviour
{
    public List<GameObject> corruptedObjs;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Corruption"))
        {
            corruptedObjs.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(corruptedObjs.Count <= 0 )
        {
            //Some kind of win condition or level clear function.
            Debug.Log("YOU WIN");
        }
    }
}
