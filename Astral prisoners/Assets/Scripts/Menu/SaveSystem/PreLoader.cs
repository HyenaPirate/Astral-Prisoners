using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class PreLoader : MonoBehaviour
{
    // Skrypt i scena sa potrzebne. Wywoluje je na poczatku zeby sie zaladowaly ustawienia z pliku.
    // Nw czemu ale wskakuja na miejsce dopiero po przeladowaniu sceny, i najlatwiej to rozwiazac tak.
    // KURWA UNITY JA CIEBIE PROSZE O CHUJ CI CHODZI 

    // W sumie mozna dac tu splash screen czy co, w sensie taki animowany a nie unitowski

    public SaveManager saveManager;
    public Slider sliderMusic;
	public Slider sliderEffects;

    public void Awake()
    {
        LocalizationSettings settings = LocalizationSettings.Instance;
        LocaleIdentifier localeCode = new LocaleIdentifier("en");  //can be "en" "de" "ja" etc.
        Debug.Log("localeCode made " + LocalizationSettings.AvailableLocales.Locales.Count);
        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if(anIdentifier == localeCode)
            {
                LocalizationSettings.SelectedLocale = aLocale;
                Debug.Log("if statement completed, " +  LocalizationSettings.SelectedLocale);
            }
        }
        Debug.Log("Finished Locale");
    }

    void Start()
    {
        

        saveManager.Load();
        // Wlaczanie ustawien -----------------------

        switch(PlayerPrefs.GetInt("Language", 0))
        {
        case 0: LoadLocale("en"); Debug.Log("Language set to English"); break; //english
        case 1: LoadLocale("pl"); Debug.Log("Language set to Polish"); break; //polish
       
        default: break;
        }

        // AUDIO
        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic", 0.8f);
        sliderEffects.value = PlayerPrefs.GetFloat("VolumeEffects", 0.8f);

        // DISPLAY
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = PlayerPrefs.GetInt("Framerate", 60);
        if(PlayerPrefs.GetInt("Framerate", -69) == -69) PlayerPrefs.SetInt("Framerate", 60);
        

        SceneManager.LoadScene(1);

        Debug.Log(PlayerPrefs.GetInt("Language", 69));

    }

public void LoadLocale(string languageIdentifier)
    {
        LocalizationSettings settings = LocalizationSettings.Instance;
        LocaleIdentifier localeCode = new LocaleIdentifier(languageIdentifier);  //can be "en" "de" "ja" etc.
        Debug.Log("localeCode made " + LocalizationSettings.AvailableLocales.Locales.Count);
        for(int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; i++)
        {
            Locale aLocale = LocalizationSettings.AvailableLocales.Locales[i];
            LocaleIdentifier anIdentifier = aLocale.Identifier;
            if(anIdentifier == localeCode)
            {
                LocalizationSettings.SelectedLocale = aLocale;
                Debug.Log("if statement completed, " +  LocalizationSettings.SelectedLocale);
            }
        }
        Debug.Log("Finished Locale");
    }

}
