using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour{

	public static bool dead = false;

	public GameObject deathMenuUI;
	
	void Update(){
		if(dead)
		{
			GameOver();
			SceneManager.LoadScene("KatiesTestScene");//Name of the Scene
		}
		
	}
	void GameOver ()
	{
		deathMenuUI.SetActive(true);
		Time.timeScale = 0.0f;
		dead = true;
	}
}