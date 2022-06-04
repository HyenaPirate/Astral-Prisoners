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

	//Duplikat z skryptu GameManager
    /*public void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<MenuInterface>().ReloadScene();
        }
    }
	*/
	public void Save()
	{
	   string[] contents = new string[] // tutaj wpisz wszystko co chcesz zapisac
	    {
		  //Settings
		  "" + PlayerPrefs.GetInt("Language", 0),

		  "" + PlayerPrefs.GetFloat("VolumeMusic", 0.8f),
		  "" + PlayerPrefs.GetFloat("VolumeEffects", 0.8f),
		  "" + PlayerPrefs.GetInt("Framerate", 60),
		  
		  
		  //Levels
          "" + PlayerPrefs.GetInt("tutorial_2", 0),
          "" + PlayerPrefs.GetInt("tutorial_3", 0),
          "" + PlayerPrefs.GetInt("tutorial_4", 0),
          "" + PlayerPrefs.GetInt("tutorial_5", 0),
          "" + PlayerPrefs.GetInt("tutorial_6", 0),
          "" + PlayerPrefs.GetInt("tutorial_7", 0),
          "" + PlayerPrefs.GetInt("tutorial_8", 0),
          "" + PlayerPrefs.GetInt("tutorial_9", 0),

          "" + PlayerPrefs.GetInt("stage_1", 0),
          "" + PlayerPrefs.GetInt("l2", 0),
          "" + PlayerPrefs.GetInt("l3", 0),
          "" + PlayerPrefs.GetInt("l4", 0),
          "" + PlayerPrefs.GetInt("l5", 0),
          "" + PlayerPrefs.GetInt("l6", 0),
          "" + PlayerPrefs.GetInt("l7", 0),
          "" + PlayerPrefs.GetInt("l8", 0),
          "" + PlayerPrefs.GetInt("l9", 0),
          "" + PlayerPrefs.GetInt("l10", 0),

          "" + PlayerPrefs.GetInt("stage_2", 0),
          "" + PlayerPrefs.GetInt("k2", 0),
          "" + PlayerPrefs.GetInt("k3", 0),
          "" + PlayerPrefs.GetInt("k4", 0),
          "" + PlayerPrefs.GetInt("k5", 0),
          "" + PlayerPrefs.GetInt("k6", 0),
          "" + PlayerPrefs.GetInt("k7", 0),
          "" + PlayerPrefs.GetInt("k8", 0),
          "" + PlayerPrefs.GetInt("k9", 0),
          "" + PlayerPrefs.GetInt("k10", 0),
		  
          "" + PlayerPrefs.GetInt("tests", 0),
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

            //Pamietaj ze [i] musi byc taka sama w jakiej kolejnosci wpisales tamto na gorze. Inaczej chuja zdzialasz tylko gre rozjebiesz
			int i=0;

			//Settings
			PlayerPrefs.SetInt("Language", int.Parse(contents[i])); i++;

			PlayerPrefs.SetFloat("VolumeMusic", float.Parse(contents[i])); i++;
			PlayerPrefs.SetFloat("VolumeEffects", float.Parse(contents[i])); i++;
			PlayerPrefs.SetInt("Framerate", int.Parse(contents[i])); i++;
			

			//Levels
            PlayerPrefs.SetInt("tutorial_2", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_3", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_4", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_5", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_6", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_7", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_8", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("tutorial_9", int.Parse(contents[i])); i++;

            PlayerPrefs.SetInt("stage_1", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l2", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l3", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l4", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l5", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l6", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l7", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l8", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l9", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("l10", int.Parse(contents[i])); i++;

            PlayerPrefs.SetInt("stage_2", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k2", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k3", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k4", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k5", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k6", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k7", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k8", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k9", int.Parse(contents[i])); i++;
            PlayerPrefs.SetInt("k10", int.Parse(contents[i])); i++;

            PlayerPrefs.SetInt("tests", int.Parse(contents[i])); i++;
			
			
			Debug.Log("Progress Loaded");
		}
		else Debug.Log("Save file has not been found");
		
		//SceneManager.LoadScene(1);
	}

}
