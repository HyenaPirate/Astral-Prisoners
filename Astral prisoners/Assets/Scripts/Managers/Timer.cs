using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Skrypt pobiera czas z GameManagera i wpisuje go w wybrany tekst. Mozna zmienic by zawsze wpisywal w siebie bo wsumie to robi
    // ale na razie trzeba go dawac recznie i nw jeszce jak to zrobic by dzialalo
    
    public Text timerText;
    

    void Start()
    {
        float t = FindObjectOfType<GameManager>().time;
        string minutes = ((int) t/60).ToString();
        string seconds = (t%60).ToString("f3");

        timerText.text = minutes+":"+seconds;
    }
}