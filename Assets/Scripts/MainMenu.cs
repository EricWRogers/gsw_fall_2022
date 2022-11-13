using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public AudioManager audio;

    public string sceneName; //We can now input the scene we want to go to
    void Update()
    {
        Play();
        PlayMusic();
    }
    void Awake()
    {

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName); //Name of the Scene
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    private void Play()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

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
        
            AudioSource sound = GameObject.Find("sound_0_Title Music").GetComponent<AudioSource>();
            sound.Play();
        
    }
}
