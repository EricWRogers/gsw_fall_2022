using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<CorruptionManager> corruptionManagers;
    private List<GameObject> enemies;
    public bool isLoading = false;
    public string sceneName;
    public void ReloadGame()
    {
        if (isLoading == false)
        {
            isLoading = true;
            SceneManager.LoadScene(sceneName); //Name of the scene

        }

        isLoading = false;

    }

    private void Start()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(obj);
        }
    }

    private void Update()
    {
        if (enemies.Count != 0)
        {
            foreach (GameObject obj in enemies)
            {
                if (obj.gameObject.activeSelf == false) //Checking to see if the objs are false
                {
                    enemies.Remove(obj);
                }
            }
        }

        foreach (CorruptionManager CM in corruptionManagers)
        {
            if((CM.cleanseableObjs.Count <= 0 && CM.corruptedObjs.Count <= 0) && enemies.Count <= 0)
            {
                Debug.Log("You Win");
            }
        }
    }
}
