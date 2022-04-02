using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;
    public int framerate;


    Resolution[] resolutions;

    public TMPro.TMP_Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate+"Hz";
            //if(resolutions[i].refreshRate == rate) 
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        framerate = Application.targetFrameRate;
        fullscreenToggle.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else vsyncToggle.isOn = true;
    }

    // Update is called once per frame


    public void ApplySettings()
    {
        Resolution resolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        Screen.fullScreen = fullscreenToggle.isOn;

        framerate = resolution.refreshRate;


        if(vsyncToggle.isOn)
        {
            //QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = framerate;
            PlayerPrefs.SetInt("Framerate", framerate);
        }
        else Application.targetFrameRate = 0;
        //QualitySettings.vSyncCount = 0;

    }
}
