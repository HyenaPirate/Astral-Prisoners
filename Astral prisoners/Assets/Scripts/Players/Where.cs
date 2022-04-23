using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Where : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Vector3Int pos;

    void Start()
    {
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
        grid = GameObject.FindWithTag("Grid").GetComponent<Grid>();
    }

    public void Update() //ustawia pos na wspolzdne tego obiektu na siatce
    {
        pos = grid.WorldToCell(transform.position);
    }
    public Vector3Int Pole(int prawo, int gora) //zwraca wspoldne pola na siatce oddalone o konkretna odleglosc
    {
        Vector3Int przesuniecie = new Vector3Int(prawo, gora, 0);
        Vector3Int wektor;
        wektor = pos + przesuniecie;
        return wektor;
    }
    
}