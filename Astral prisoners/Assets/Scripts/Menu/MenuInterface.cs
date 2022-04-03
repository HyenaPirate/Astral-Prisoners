using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
public class MenuInterface : MonoBehaviour
{   
    // Skrypt do zarzadzania interfacem menu, ladowaniem scen, pauzowaniem gry itp

    public LevelLoader loader;

    void Start()
    {
       Sound_Music();
    }

// Scene Management -----------------------------------------

    public void LoadLevel(int lvl)
    {
        if(loader == null){ SceneManager.LoadScene(lvl); /*Debug.Log("nie ma loadera");*/}
        else{ loader.LoadLevel(lvl); /*Debug.Log("jest loader");*/}
    }

    public void LoadMainMenu()
    {
        LoadLevel(1);
    }

    public void ReloadScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(scene);
    }

    public void NextScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        LoadLevel(scene + 1);
    }

    public void QuitGame()
    {
	  if(FindObjectOfType<SaveManager>() != null) FindObjectOfType<SaveManager>().Save();
	  PlayerPrefs.DeleteAll();
	  Application.Quit(); 
      Debug.Log("Game has been shut down");
    }


// PAUSE ------------------------------------------------------

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
        FindObjectOfType<AudioManager>().Play("Music");
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
