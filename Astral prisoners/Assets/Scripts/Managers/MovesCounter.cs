using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesCounter : MonoBehaviour
{
    // Skrypt bierze liczbe ruchow z GameManagera i wpisuje je w wybrany tekst

    public Text numMoves;

    public void GetMoves()
    {
        string ruchy = (FindObjectOfType<GameManager>().iloscRuchow).ToString();
        numMoves.text = ruchy;
    }
}
