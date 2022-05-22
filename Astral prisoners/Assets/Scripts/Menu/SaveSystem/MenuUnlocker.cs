using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuUnlocker : MonoBehaviour
{
    // Skrypt sluzy do odblokiwania poziomow i wczytywania ustawien


    public SaveManager saveManager;
    public Color lockedLevelColor; // Kolor tekstu zablokowanej opcji


    // Tutaj dajesz czym zarzadamy.

    // SETTINGS -----------------------
	public Slider sliderMusic;
	public Slider sliderEffects;


    // LEVELS -------------------------

    // Tutorials
    //public GameObject[] tutorials;
    public GameObject tutorial_2;
    public GameObject tutorial_3;
    public GameObject tutorial_4;
    public GameObject tutorial_5;
    public GameObject tutorial_6;
    public GameObject tutorial_7;
    public GameObject tutorial_8;
    public GameObject tutorial_9;

    public GameObject stage_1;
    public GameObject l2;
    public GameObject l3;

    public GameObject tests;

    void Start() // Tutaj ladujemy ustawienia i lockujemy odpowiednie poziomy
    {
        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic", 0.8f);
        sliderEffects.value = PlayerPrefs.GetFloat("VolumeEffects", 0.8f);


        // LEVELS -----------------------

        // tutorials
        if(PlayerPrefs.GetInt("tutorial_2") != 1) Lock(tutorial_2);
        if(PlayerPrefs.GetInt("tutorial_3") != 1) Lock(tutorial_3);
        if(PlayerPrefs.GetInt("tutorial_4") != 1) Lock(tutorial_4);
        if(PlayerPrefs.GetInt("tutorial_5") != 1) Lock(tutorial_5);
        if(PlayerPrefs.GetInt("tutorial_6") != 1) Lock(tutorial_6);
        if(PlayerPrefs.GetInt("tutorial_7") != 1) Lock(tutorial_7);
        if(PlayerPrefs.GetInt("tutorial_8") != 1) Lock(tutorial_8);
        if(PlayerPrefs.GetInt("tutorial_9") != 1) Lock(tutorial_9);

        // stage I
        if(PlayerPrefs.GetInt("stage_1") != 1) Lock(stage_1);
        if(PlayerPrefs.GetInt("l2") != 1) Lock(l2);
        if(PlayerPrefs.GetInt("l3") != 1) Lock(l3);

        if(PlayerPrefs.GetInt("tests") != 1) Lock(tests);
        


    }

    private void Lock(GameObject thing) // Funkcja Wylacza mozliwosc korzystania z elementu UI
    {
        // Wylacz Przycisk
        if(thing.GetComponent<Button>() != null) thing.GetComponent<Button>().interactable = false;
        
        // Zmien Kolor TextMeshPro
        thing.GetComponentInChildren<TextMeshProUGUI>().faceColor = lockedLevelColor;

    }

    public void DeleteProgress()
    {
        PlayerPrefs.SetInt("tutorial_2", 0);
        PlayerPrefs.SetInt("tutorial_3", 0);
        PlayerPrefs.SetInt("tutorial_4", 0);
        PlayerPrefs.SetInt("tutorial_5", 0);
        PlayerPrefs.SetInt("tutorial_6", 0);
        PlayerPrefs.SetInt("tutorial_7", 0);
        PlayerPrefs.SetInt("tutorial_8", 0);
        PlayerPrefs.SetInt("tutorial_9", 0);

        PlayerPrefs.SetInt("stage_1", 0);
        PlayerPrefs.SetInt("l2", 0);
        PlayerPrefs.SetInt("l3", 0);

        PlayerPrefs.SetInt("tests", 0);
        
        saveManager.Save();
    }

    public void UnlockAll()
    {
        PlayerPrefs.SetInt("tutorial_2", 1);
        PlayerPrefs.SetInt("tutorial_3", 1);
        PlayerPrefs.SetInt("tutorial_4", 1);
        PlayerPrefs.SetInt("tutorial_5", 1);
        PlayerPrefs.SetInt("tutorial_6", 1);
        PlayerPrefs.SetInt("tutorial_7", 1);
        PlayerPrefs.SetInt("tutorial_8", 1);
        PlayerPrefs.SetInt("tutorial_9", 1);

        PlayerPrefs.SetInt("stage_1", 1);
        PlayerPrefs.SetInt("l2", 1);
        PlayerPrefs.SetInt("l3", 1);

        PlayerPrefs.SetInt("tests", 1);
        
        saveManager.Save();
    }

}
