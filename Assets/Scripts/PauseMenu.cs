using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{

   public static bool GameIsPaused = false;

   public GameObject pauseMenuUI;

   void Update(){
		  if(Input.GetKeyDown(KeyCode.Escape))
		  {
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
   void Resume ()
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
}
