using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public string sceneName; //We can now input the scene we want to go to

   public void PlayGame ()
   {
		  SceneManager.LoadScene(sceneName); //Name of the Scene
   }
   public void QuitGame ()
   {
		  Debug.Log("QUIT!");
		  Application.Quit();
   }
}
