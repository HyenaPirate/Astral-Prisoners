using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.IO;
public class MenuInterface : MonoBehaviour
{   
    void Start()
    {
        Sound_Music();
    }

// Scene Management -----------------------------------------

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame()
    {
	  //saveManager.Save();
	  //PlayerPrefs.DeleteAll();
	  Application.Quit(); 
      Debug.Log("Game has been shut down");
    }

    public void PauseGame()
    {
        FindObjectOfType<GameManager>().gameIsPaused = true;
    }

    public void ResumeGame()
    {
        FindObjectOfType<GameManager>().gameIsPaused = false;
    }

// Audio ---------------------------------------------------

    public void Sound_Music()
    {
        FindObjectOfType<AudioManager>().Play("MainMenuMusic");
    }

    public void Sound_Select()
    {
        FindObjectOfType<AudioManager>().Play("Select");
    }

    public void Sound_Return()
    {
        FindObjectOfType<AudioManager>().Play("Return");
    }

}
