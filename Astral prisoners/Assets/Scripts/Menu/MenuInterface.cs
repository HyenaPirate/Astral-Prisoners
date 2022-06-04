using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class MenuInterface : MonoBehaviour
{   
    // Skrypt do zarzadzania interfacem menu, ladowaniem scen, pauzowaniem gry itp

    public LevelLoader loader;
    public GameObject screensFolder;

    void Awake()
    {
        if(screensFolder != null) screensFolder.SetActive(true); // Wlacza Folder ze Screenami, potrzebne by wszystko sie polaczylo, a pozwala wylaczyc go na czas testow i sie nie przejmowac

        // Dla kazdego AudioManagera niech on sprawdzi czy ma sie usunac
       // AudioManager[] am = (AudioManager[]) GameObject.FindObjectsOfType (typeof(AudioManager));
        //foreach (AudioManager manager in am) manager.CheckInstance();


        loader = FindObjectOfType<LevelLoader>();
    }
    
    void Start()
    {
       //Sound_Music();
       
       //Zagraj muzyke z isniejacego AudioManagera
       FindObjectOfType<AudioManager>().Play("Music");
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

// LANGUAGE -----------------------------------------------

public void ChangeLanguage(int language)
{
    switch(language)
    {
        case 0: LoadLocale("en"); break; //english
        case 1: LoadLocale("pl"); break; //polish
       
        default: break;
    }
    PlayerPrefs.SetInt("Language", language);
}

private void LoadLocale(string languageIdentifier)
    {
        LocalizationSettings settings = LocalizationSettings.Instance;
        LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);  //can be "en" "de" "ja" etc.
        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if(anIdentifier == localeCode)
            {
                LocalizationSettings.SelectedLocale = aLocale;
            }
        }
    }


// PAUSE ------------------------------------------------------

    public void PauseGame()
    {
        FindObjectOfType<GameManager>().gameIsPaused = true;
    }

    public void ResumeGame()
    {
        if(FindObjectOfType<GameManager>().gameIsOver == false) FindObjectOfType<GameManager>().gameIsPaused = false;
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
