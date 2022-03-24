using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Ta klasa s³u¿y dodatkowo za przyk³ad jak u¿yæ klasy Hackable
W przypadku kolejnych u¿yæ klasy hackable nie ma potrzeby tak dok³adnego komentowania
*/
public class Button : Hackable // <----- Dziedziczê po hackable (Hackable dziedziczy po MonoBehaviour wiêc ta klasa te¿ z automatu i nie muszê tego pisaæ)
{
    private GameManager gameManager;
    public int button_id; //który sygna³ ma ustawiaæ ten przycisk
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    /*
     Poniewa¿ klasa hackable jest abstrakcyjna trzeba zaimplementowaæ metodê hack kiedy jej u¿ywasz
     Trzeba u¿yæ override przed
     Kod zawarty w tej funkcji bêdzie u¿yty przez robota gdy bêdzie hackowa³ przedmiot który ma ten skrypt

     Pamiêtaj aby obiekt hackowalny mia³ tag hack i by³ postawiony równo na œrodku kratki
     */ 
    override public void Hack() //Implementujê w³an¹ metodê hack
    {
        gameManager.GetComponent<Signals>().signal[button_id] = true; //ustawiam sygna³ o numerze button_id na prawdziwy
    }
}
