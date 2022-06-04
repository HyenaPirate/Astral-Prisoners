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
    public GameObject l4;
    public GameObject l5;
    public GameObject l6;
    public GameObject l7;
    public GameObject l8;
    public GameObject l9;
    public GameObject l10;

    public GameObject stage_2;
    public GameObject k2;
    public GameObject k3;
    public GameObject k4;
    public GameObject k5;
    public GameObject k6;
    public GameObject k7;
    public GameObject k8;
    public GameObject k9;
    public GameObject k10;

    public GameObject tests;

    void Awake() // Tutaj ladujemy ustawienia i lockujemy odpowiednie poziomy
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
        if(PlayerPrefs.GetInt("l4") != 1) Lock(l4);
        if(PlayerPrefs.GetInt("l5") != 1) Lock(l5);
        if(PlayerPrefs.GetInt("l6") != 1) Lock(l6);
        if(PlayerPrefs.GetInt("l7") != 1) Lock(l7);
        if(PlayerPrefs.GetInt("l8") != 1) Lock(l8);
        if(PlayerPrefs.GetInt("l9") != 1) Lock(l9);
        if(PlayerPrefs.GetInt("l10") != 1) Lock(l10);

        // stage I
        if(PlayerPrefs.GetInt("stage_2") != 1) Lock(stage_2);
        if(PlayerPrefs.GetInt("k2") != 1) Lock(k2);
        if(PlayerPrefs.GetInt("k3") != 1) Lock(k3);
        if(PlayerPrefs.GetInt("k4") != 1) Lock(k4);
        if(PlayerPrefs.GetInt("k5") != 1) Lock(k5);
        if(PlayerPrefs.GetInt("k6") != 1) Lock(k6);
        if(PlayerPrefs.GetInt("k7") != 1) Lock(k7);
        if(PlayerPrefs.GetInt("k8") != 1) Lock(k8);
        if(PlayerPrefs.GetInt("k9") != 1) Lock(k9);
        if(PlayerPrefs.GetInt("k10") != 1) Lock(k10);

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
        PlayerPrefs.SetInt("l4", 0);
        PlayerPrefs.SetInt("l5", 0);
        PlayerPrefs.SetInt("l6", 0);
        PlayerPrefs.SetInt("l7", 0);
        PlayerPrefs.SetInt("l8", 0);
        PlayerPrefs.SetInt("l9", 0);
        PlayerPrefs.SetInt("l10", 0);

        PlayerPrefs.SetInt("stage_2", 0);
        PlayerPrefs.SetInt("k2", 0);
        PlayerPrefs.SetInt("k3", 0);
        PlayerPrefs.SetInt("k4", 0);
        PlayerPrefs.SetInt("k5", 0);
        PlayerPrefs.SetInt("k6", 0);
        PlayerPrefs.SetInt("k7", 0);
        PlayerPrefs.SetInt("k8", 0);
        PlayerPrefs.SetInt("k9", 0);
        PlayerPrefs.SetInt("k10", 0);

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
        PlayerPrefs.SetInt("l4", 1);
        PlayerPrefs.SetInt("l5", 1);
        PlayerPrefs.SetInt("l6", 1);
        PlayerPrefs.SetInt("l7", 1);
        PlayerPrefs.SetInt("l8", 1);
        PlayerPrefs.SetInt("l9", 1);
        PlayerPrefs.SetInt("l10", 1);

        PlayerPrefs.SetInt("stage_2", 1);
        PlayerPrefs.SetInt("k2", 1);
        PlayerPrefs.SetInt("k3", 1);
        PlayerPrefs.SetInt("k4", 1);
        PlayerPrefs.SetInt("k5", 1);
        PlayerPrefs.SetInt("k6", 1);
        PlayerPrefs.SetInt("k7", 1);
        PlayerPrefs.SetInt("k8", 1);
        PlayerPrefs.SetInt("k9", 1);
        PlayerPrefs.SetInt("k10", 1);

        PlayerPrefs.SetInt("tests", 1);
        
        saveManager.Save();
    }

}
