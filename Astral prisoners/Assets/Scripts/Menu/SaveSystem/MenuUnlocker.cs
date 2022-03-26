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

    // SETTINGS
	public Slider sliderMusic;
	public Slider sliderEffects;


    // LEVELS
    public GameObject tutorialDemon;
    public GameObject tutorialRobot;

    void Start() // Tutaj ladujemy ustawienia i lockujemy odpowiednie poziomy
    {
        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic", 0.8f);
        sliderEffects.value = PlayerPrefs.GetFloat("VolumeEffects", 0.8f);


        // LEVELS
        if(PlayerPrefs.GetInt("TutorialDemon") != 1) Lock(tutorialDemon);
        if(PlayerPrefs.GetInt("TutorialRobot") != 1) Lock(tutorialRobot);


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
        PlayerPrefs.SetInt("TutorialDemon", 0);
        PlayerPrefs.SetInt("TutorialRobot", 0);
        saveManager.Save();
    }

}
