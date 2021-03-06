using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused = true;
    public bool gameIsOver = false;
    GameObject gameOverScreen;
    public GameObject aktywnosc;
    public string odblokowujeLevel; // Jezeli chcesz by przejscie poziomu odblokowalo jakis inny, tutaj piszesz PlayerPrefs tego poziomu
    private int r_timer = 0;

    //STATYSTYKI -----------------
    public double iloscRuchow = 0;

    private float startTime;
    public bool done = false; 
    public float time;
    public void StartTime(){ startTime = Time.time; }
    public void StopTime(){ done = true; }
    
    public void Start()
    {
        gameOverScreen = GameObject.FindWithTag("GameOverScreen");
        gameOverScreen.SetActive(false);
        aktywnosc = GameObject.FindWithTag("ActiveSprite");
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

        if (Input.GetKey(KeyCode.R) && gameIsPaused == false)
        {
            Debug.Log(r_timer);
            r_timer++;
            if (r_timer >= 90)
            {
                FindObjectOfType<MenuInterface>().ReloadScene();
            }
        }
        else
        {
            r_timer = 0;
        }
    }

    public void GameOver()
    {
        gameIsOver = true;
        gameIsPaused = true;
        gameOverScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Music");
        FindObjectOfType<AudioManager>().Play("Przegrana");
    }

}
