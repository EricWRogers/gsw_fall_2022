using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionGetter : MonoBehaviour
{
    public void Remove()
    {
        CorruptionManager CM = FindObjectOfType<CorruptionManager>();
        CM.corruptedObjs.Remove(gameObject);
    }
}
