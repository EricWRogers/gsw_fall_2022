using System.Collections.Generic;
using UnityEngine;

public class CorruptionManager : MonoBehaviour
{
    public List<GameObject> cleanseableObjs;
    public List<GameObject> lights;
    public List<GameObject> corruptedObjs;

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Corruption"))
        {
            corruptedObjs.Add(obj);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in cleanseableObjs)
        {
            if (obj.gameObject.activeSelf == false) //Checking to see if the objs are false
            {
                cleanseableObjs.Remove(obj);
            }
        }

        foreach (GameObject obj in corruptedObjs)
        {
            if (obj.gameObject.activeSelf == false) //Checking to see if the objs are false
            {
                corruptedObjs.Remove(obj);
            }
        }

        if (cleanseableObjs.Count <= 0 && corruptedObjs.Count <= 0)
        {
            foreach (GameObject obj in lights)
            {
                obj.GetComponent<Animator>().SetTrigger("Cleanse"); //Changes light color
            }

        }
    }


}
