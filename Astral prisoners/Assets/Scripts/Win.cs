using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Win : MonoBehaviour
{ 
    public Tilemap tilemap;
    public GameObject[] gracze;
    private int ile_graczy;
    public MenuInterface menu;
    void Start()
    {
        ile_graczy = GameObject.FindGameObjectsWithTag("Player").Length; // na poczatku sprawdza ile jest graczy
    }
    void Update()
    {
        if (ile_graczy == 0) 
        {
            menu.LoadMainMenu(); //po usunieciu wszystkich graczy wlancza sie menu
        }
        gracze = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < gracze.Length; i++)
        {
            if (tilemap.GetTile(gracze[i].GetComponent<Where>().Pole(0, 0)).name == "Wygrana") //sprawdza czy ktorys z graczy stoi na polu "Wygrana"
            {
                Destroy(gracze[i]); //gracz jest usuwany
                 ile_graczy--;
            }
        }
    }
}
