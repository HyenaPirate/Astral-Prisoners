using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject indentyfikator;
    bool activePlayer;
    GameObject[] gracze;
    public bool GetActivePlayer() // Geter, upewniam siê ¿e nikt nie zmieni tej zmiennej gdy nie trzeba
    {
        return activePlayer;
    }
    void Start() //Dezaktywuje graczy na pocz¹tku
    {
        activePlayer = false;
    }
    void OnMouseDown()
    {
        gracze = GameObject.FindGameObjectsWithTag("Player");
        for (int i=0; i<gracze.Length; i++)
        {
            gracze[i].GetComponent<Activate>().Start(); //wszyscy gracze staj¹ siê nieaktywni, bo metoda start dezaktywuje graczy
        }
        activePlayer = true; //ten gracz staje siê aktywny
    }
    private void Update()
    {
        indentyfikator.SetActive(activePlayer); //je¿eli dany gracz jest aktywny to wyœwietla ten kwadracik
    }


}
