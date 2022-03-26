using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreLoader : MonoBehaviour
{
    // Skrypt i scena sa potrzebne. Wywoluje je na poczatku zeby sie zaladowaly ustawienia z pliku.
    // Nw czemu ale wskakuja na miejsce dopiero po przeladowaniu sceny, i najlatwiej to rozwiazac tak.
    // KURWA UNITY JA CIEBIE PROSZE O CHUJ CI CHODZI 

    // W sumie mozna dac tu splash screen czy co, w sensie taki animowany a nie unitowski

    public SaveManager saveManager;
    public Slider sliderMusic;
	public Slider sliderEffects;
    void Start()
    {
        saveManager.Load();

        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic", 0.8f);
        sliderEffects.value = PlayerPrefs.GetFloat("VolumeEffects", 0.8f);

        SceneManager.LoadScene(1);
    }

}
