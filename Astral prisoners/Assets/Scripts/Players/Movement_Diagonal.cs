using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_Diagonal : Movement
{
    
    override public void MoveCharacter()
    {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(-1, 1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(-1, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(1, 1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(1, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(-1, -1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(-1, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(1, -1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(1, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
        }
}
