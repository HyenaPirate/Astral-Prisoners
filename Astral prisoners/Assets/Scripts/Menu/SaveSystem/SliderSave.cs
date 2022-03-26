using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSave : MonoBehaviour
{
    // Skrypt nadaje wlasciwa pozycje sliderowi. Podaj tylko co kontroluje: z czego ma wczytac wartosc

    public string prefs;
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat(prefs, GetComponent<Slider>().value);
        //Debug.Log(PlayerPrefs.GetFloat(prefs, 69f));
    }

    void Start()
    {
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(prefs, 0.8f);
        //Debug.Log(PlayerPrefs.GetFloat(prefs, 69f));
    }
}
