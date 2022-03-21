using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Where : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public Vector3Int pos;
    void Update() //ustawia pos na wsp��dne tego obiektu na siatce
    {
        pos = grid.WorldToCell(transform.position);
    }
    public Vector3Int Pole(int prawo, int gora) //zwraca wsp��dne pola na siatce oddalone o konkretn� odleg�o��
    {
        Vector3Int przesuniecie = new Vector3Int(prawo, gora, 0);
        Vector3Int wektor;
        wektor = pos + przesuniecie;
        return wektor;
    }
    
}