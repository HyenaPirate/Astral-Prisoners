using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    bool isActive;
    GameObject[] gracze;
    public bool IsActive() // Geter, upewniam sie ze nikt nie zmieni tej zmiennej gdy nie trzeba
    {
        return isActive;
    }
    public static GameObject GetActivePlayer() //Zwraca aktywnego gracza
    {
        Activate[] players  = FindObjectsOfType<Activate>();
        for (int i=0; i<players.Length; i++)
        {
            if (players[i].isActive) return players[i].gameObject; 
        }
        return null; //lub NULL jeżeli nikt nie jest aktywny
    }
    void Start() //Dezaktywuje graczy na poczatku
    {
        isActive = false;
    }
    void OnMouseDown()
    {
        if(FindObjectOfType<GameManager>().gameIsPaused == false)
        {
            gracze = GameObject.FindGameObjectsWithTag("Player");
            for (int i=0; i<gracze.Length; i++)
            {
                gracze[i].GetComponent<Activate>().Start(); //wszyscy gracze staja sie nieaktywni, bo metoda start dezaktywuje graczy
            }
            isActive = true; //ten gracz staje sie aktywny
            FindObjectOfType<AudioManager>().Play("Wybor");
        }
    }
}
