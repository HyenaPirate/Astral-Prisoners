using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Where : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    Vector3Int pos;
    void Update() //ustawia pos na wspó³¿êdne tego obiektu na siatce
    {
        pos = grid.WorldToCell(transform.position);
    }
    public Vector3Int Pole(int prawo, int gora) //zwraca wspó³¿êdne pola na siatce oddalone o konkretn¹ odleg³oœæ
    {
        Vector3Int przesuniecie = new Vector3Int(prawo, gora, 0);
        Vector3Int wektor;
        wektor = pos + przesuniecie;
        return wektor;
    }
    
}
