using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;


    Resolution[] resolutions;

    public TMPro.TMP_Dropdown resolutionDropdown;

    void Start()
    {
        // Creating a list of avaible resolutions -------------
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + " Hz";
            options.Add(option);

            // Setting the dropdown menu value to match applied settings
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                if(PlayerPrefs.GetInt("Framerate", 60) == 0)
                {
                    if(resolutions[i].refreshRate == 60) currentResolutionIndex = i;
                }
                else if(resolutions[i].refreshRate == PlayerPrefs.GetInt("Framerate", 60)) currentResolutionIndex = i;
            } 

        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Setting the toggles ----------------
        fullscreenToggle.isOn = Screen.fullScreen;

        if(PlayerPrefs.GetInt("Framerate", 60) != 0)
        {
            vsyncToggle.isOn = true;
        }
        else vsyncToggle.isOn = false;
    }

    public void ApplySettings()
    {
        // RESOLUTION
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Screen.fullScreen = fullscreenToggle.isOn;


        // V-SYNC        
        

        if(vsyncToggle.isOn)
        {
            Application.targetFrameRate = resolution.refreshRate;
            PlayerPrefs.SetInt("Framerate", resolution.refreshRate);
        }
        else
        {
            Application.targetFrameRate = 0;
            PlayerPrefs.SetInt("Framerate", 0);
        }

    }
}
