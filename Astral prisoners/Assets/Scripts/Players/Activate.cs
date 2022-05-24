using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    bool isActive;
    static GameObject[] gracze;
    public int id_postaci;
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
    private static void ActivatePlayer(int id)
    {
        if (FindObjectOfType<GameManager>().gameIsPaused == false)
        {
            gracze = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < gracze.Length; i++)
            {
                if(gracze[i].GetComponent<Activate>().id_postaci == id)
                    gracze[i].GetComponent<Activate>().isActive = true;
                else
                    gracze[i].GetComponent<Activate>().isActive = false;
            }
            FindObjectOfType<AudioManager>().Play("Wybor");
        }
    }
    void OnMouseDown()
    {
        ActivatePlayer(transform.GetComponent<Activate>().id_postaci); //aktywuje tego gracza
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && id_postaci==1)
        {
            ActivatePlayer(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && id_postaci==2)
        {
            ActivatePlayer(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && id_postaci == 3)
        {
            ActivatePlayer(3);
        }
    }
}
