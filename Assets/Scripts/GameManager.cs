using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isLoading = false;
    public string sceneName;
    public void ReloadGame()
    {
        if (isLoading == false)
        {
            isLoading = true;
            SceneManager.LoadScene("LevelOne"); //Name of the scene

        }

        isLoading = false;

    }
}
