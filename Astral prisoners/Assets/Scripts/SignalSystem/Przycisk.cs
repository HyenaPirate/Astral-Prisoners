using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Ta klasa s�u�y dodatkowo za przyk�ad jak u�y� klasy Hackable
W przypadku kolejnych u�y� klasy hackable nie ma potrzeby tak dok�adnego komentowania
*/
public class Przycisk : Hackable // <----- Dziedzicz� po hackable (Hackable dziedziczy po MonoBehaviour wi�c ta klasa te� z automatu i nie musz� tego pisa�)
{
    private GameManager gameManager;
    public int button_id; //kt�ry sygna� ma ustawia� ten przycisk
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    /*
     Poniewa� klasa hackable jest abstrakcyjna trzeba zaimplementowa� metod� hack kiedy jej u�ywasz
     Trzeba u�y� override przed
     Kod zawarty w tej funkcji b�dzie u�yty przez robota gdy b�dzie hackowa� przedmiot kt�ry ma ten skrypt

     Pami�taj aby obiekt hackowalny mia� tag hack i by� postawiony r�wno na �rodku kratki
     */ 
    override public void Hack() //Implementuj� w�an� metod� hack
    {
        gameManager.GetComponent<Signals>().signal[button_id] = true; //ustawiam sygna� o numerze button_id na prawdziwy
    }
}
