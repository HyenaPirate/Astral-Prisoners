using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Skrypt pobiera czas z GameManagera i wpisuje go w tekst na tym samym GameObjecie.
    
    public Text timerText;
    GameManager gm;
    
    public void Awake()
    {
        timerText = GetComponent<Text>();
        gm = FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        if(gm.done)
        {
            float t = gm.time;
            string minutes = ((int) t/60).ToString();
            string seconds = (t%60).ToString("f3");
            timerText.text = minutes+":"+seconds;
        }

        
    }
    
}