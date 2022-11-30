using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
	public AudioManager audio;

	public static bool dead = false;

	public GameObject deathMenuUI;

	void Update()
	{
		if (dead)
		{
			GameOver();
			Play();
			SceneManager.LoadScene("KatiesTestScene");//Name of the Scene
		}

	}
	void GameOver()
	{
		deathMenuUI.SetActive(true);
		Time.timeScale = 0.0f;
		dead = true;
	}
	private void Play()
	{
		Debug.Log("Eric Look " + name);
		AudioSource sound = GameObject.Find("sound_2_uiBgMusic").GetComponent<AudioSource>();
		sound.Play();
	}
}