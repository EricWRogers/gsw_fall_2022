using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	public static bool GameIsPaused = false;

	public AudioManager audio;
	public GameObject pauseMenuUI;


	void Start()
	{
		//PlayMusic();
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Play();
			if (GameIsPaused)
			{
				Resume();

			}
			else
			{

				Pause();
			}
		}
	}
	void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1.0f;
		GameIsPaused = false;
	}

	void Pause()
	{


		pauseMenuUI.SetActive(true);
		Time.timeScale = 0.0f;
		GameIsPaused = true;
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
		/*private void PlayMusic()
		{
			Debug.Log("Eric Look " + name);
			AudioSource sound = GameObject.Find("sound_2_uiBGMusic").GetComponent<AudioSource>();
			sound.Play();

		} */
	}




