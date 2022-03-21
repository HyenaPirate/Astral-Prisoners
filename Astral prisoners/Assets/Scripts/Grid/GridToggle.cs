using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridToggle : MonoBehaviour
{
    public GameObject render;
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameIsPaused == false && Input.GetKeyDown(KeyCode.G))
        {
            render.GetComponent<TilemapRenderer>().enabled = !render.GetComponent<TilemapRenderer>().enabled; //odwraca wlaczenie obiektu renderujacego siatke
        }
    }
}
