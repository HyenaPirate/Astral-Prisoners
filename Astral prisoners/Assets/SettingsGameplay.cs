using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGameplay : MonoBehaviour
{
    public TMPro.TMP_Dropdown languageDropdown;

    public void Start()
    {
        languageDropdown.value = PlayerPrefs.GetInt("Language", 0);
    }

    public void UpdateLanguage()
    {
        FindObjectOfType<MenuInterface>().ChangeLanguage(languageDropdown.value);
    }
}
