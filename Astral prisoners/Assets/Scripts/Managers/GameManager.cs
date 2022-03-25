using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused = true;
    public GameObject aktywnosc;
    

    //STATYSTYKI -----------------
    public double iloscRuchow = 0;

    private float startTime;
    private bool done = false; 
    public float time;
    public void StartTime(){ startTime = Time.time; }
    public void StopTime(){ done = true; }
    

    public void Start()
    {
        gameIsPaused = false; //Odpauzowuje gre i pozwala graczowi na ruszanie postaciami, bo juz wszystko sie zaladowalo.
        StartTime();
    }
    public void Update()
    {
        if(!done) time = Time.time - startTime; //TIMER

        GameObject postac = Activate.GetActivePlayer(); //Pobieram aktywnego gracza
        if (postac != null)
        {
            aktywnosc.transform.position = postac.transform.position;
            aktywnosc.SetActive(true);
        }
        else
        {
            aktywnosc.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && gameIsPaused == false)
        {
            FindObjectOfType<MenuInterface>().ReloadScene();
        }
    }
}
