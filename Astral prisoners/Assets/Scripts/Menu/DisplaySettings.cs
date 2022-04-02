using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public Toggle vsyncToggle;
    public int framerate;

    // Start is called before the first frame update
    void Start()
    {
        framerate = Application.targetFrameRate;
        fullscreenToggle.isOn = Screen.fullScreen;

        if(QualitySettings.vSyncCount == 0)
        {
            vsyncToggle.isOn = false;
        }
        else vsyncToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplySettings()
    {
        Screen.fullScreen = fullscreenToggle.isOn;


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
