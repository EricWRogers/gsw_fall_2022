using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public bool isLoading = false;
    public AudioManager audio;

    public string sceneName; //We can now input the scene we want to go to
    void Start()
    {
        PlayMusic();
    }
    void Update()
    {
        Play();
    }
    
    public void PlayGame()
    {
        if(isLoading == false)
        {
            isLoading = true;
            SceneManager.LoadScene(sceneName); //Name of the scene
            
        }

        isLoading = false;
       
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    private void Play()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("No Sound Called");
            AudioSource sound = GameObject.Find("sound_9_uiButton").GetComponent<AudioSource>();
            sound.Play();
        }
        else
        {
            
            return;
        }
    }
   private void PlayMusic()
    {
            Debug.Log("Eric Look " + name);
            AudioSource sound = GameObject.Find("sound_0_Title Music").GetComponent<AudioSource>();
            sound.Play();
    }
}
