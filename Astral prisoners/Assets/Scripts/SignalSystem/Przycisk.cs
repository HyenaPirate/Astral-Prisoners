using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Ta klasa sluzy dodatkowo za przyklad jak uzyc klasy Hackable
W przypadku kolejnych uzyc klasy hackable nie ma potrzeby tak dokladnego komentowania
*/
public class Przycisk : Hackable // <----- Dziedziczy po hackable (Hackable dziedziczy po MonoBehaviour wiec ta klasa tez z automatu i nie musze tego pisac)
{
    private GameManager gameManager;
    public int button_id; //ktory sygnal ma ustawiac ten przycisk
    private SpriteRenderer spriteRenderer;
    public Sprite on;
    private Sprite off;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        off = spriteRenderer.sprite ; //off to po prostu domyslny sprite przycisku
    }
    private void Update()
    {
        if (gameManager.GetComponent<Signals>().signal[button_id])
            spriteRenderer.sprite = on;
        else
            spriteRenderer.sprite = off;
    }
    /*
     Poniewaz klasa hackable jest abstrakcyjna trzeba zaimplementowac metode hack kiedy jej uzywasz
     Trzeba uzyc override przed
     Kod zawarty w tej funkcji bedzie uzyty przez robota gdy b�dzie hackowac przedmiot ktory ma ten skrypt

     Pamietaj aby obiekt hackowalny mial tag hack i byc postawiony rowno na srodku kratki
     */
    override public void Hack() //Implementuje wlana metode hack
    {
        gameManager.GetComponent<Signals>().signal[button_id] = !gameManager.GetComponent<Signals>().signal[button_id]; //ustawiam sygnal o numerze button_id na prawdziwy
    }
}
