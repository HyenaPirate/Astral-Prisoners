using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveManager : MonoBehaviour
{
    // Skrypt zapisuje do pliku dane z PlayerPrefs , co pozwala na pozniejsze wczytanie.
    // Nie chcemy polegac na PlayerPrefs pomiedzy uruchomieniami gry poniewaz mogo zostac nadpisane
    // przez inne programy unity, w tym tez inne wersje naszej gry. A tak kazda ma wlasny save w swoim folderze

	private const string SAVE_SEPARATOR = "#saveseparationintensifies#";

    public void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<MenuInterface>().ReloadScene();
        }
    }

	public void Save()
	{
	   string[] contents = new string[] // tutaj wpisz wszystko co chcesz zapisac
	    {
		  //Settings
		  "" + PlayerPrefs.GetFloat("VolumeMusic", 0.8f),
		  "" + PlayerPrefs.GetFloat("VolumeEffects", 0.8f),
		  
		  //Levels
          "" + PlayerPrefs.GetInt("TutorialDemon", 0),
          "" + PlayerPrefs.GetInt("TutorialRobot", 0),
	    };
	   
	   
	   string saveString = string.Join(SAVE_SEPARATOR, contents);
	   File.WriteAllText(Application.dataPath + "/save.txt", saveString);
	   Debug.Log("Progress Saved");
       //Debug.Log(PlayerPrefs.GetFloat("VolumeMusic", 69f));
    }


	public void Load() // Wczytuje wszystko. Wywoluje go po uruchomieniu gry, bo w jej trakcie posluguje sie PlayerPrefsami
	{
		PlayerPrefs.DeleteAll(); //usuwa wszystkie PlayerPrefs aby nie wczytac czegos czego nie powinno byc
		
		if (System.IO.File.Exists(Application.dataPath + "/save.txt"))
		{
			Debug.Log("File has been found");
			string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
			string[] contents = saveString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

            //Pamietaj ze [ta liczba] musi byc taka sama w jakiej kolejnosci wpisales tamto na gorze. Inaczej chuja zdzialasz tylko gre rozjebiesz
			
			
			//Settings
			PlayerPrefs.SetFloat("VolumeMusic", float.Parse(contents[0]));
			PlayerPrefs.SetFloat("VolumeEffects", float.Parse(contents[1]));

			//Levels
            PlayerPrefs.SetInt("TutorialDemon", int.Parse(contents[2]));
            PlayerPrefs.SetInt("TutorialRobot", int.Parse(contents[3]));
			
			
			Debug.Log("Progress Loaded");
		}
		else Debug.Log("Save file has not been found");
		
		//SceneManager.LoadScene(1);
	}

}
