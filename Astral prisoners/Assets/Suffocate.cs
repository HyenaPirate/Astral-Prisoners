using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Suffocate : MonoBehaviour
{
    private Tilemap tilemap;
    private GameManager gameManager;
    private void Awake()
    {
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if(tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Pdl")
        {
            gameManager.GameOver();
        }
    }
}
