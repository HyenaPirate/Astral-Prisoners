using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_Jump : Movement
{
    override public void MoveCharacter()
    {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Dzr" && tilemap.GetTile(GetComponent<Where>().Pole(0, 2)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(0, 2) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                    if (tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Dzr" && tilemap.GetTile(GetComponent<Where>().Pole(0, -2)).name.Substring(0, 3) == "Pdl")
                    {
                        transform.position = GetComponent<Where>().Pole(0, -2) + korekta;
                        FindObjectOfType<AudioManager>().Play("Ruch");
                        FindObjectOfType<GameManager>().iloscRuchow++;
                    }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                    if (tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Dzr" && tilemap.GetTile(GetComponent<Where>().Pole(-2, 0)).name.Substring(0, 3) == "Pdl")
                    {
                        transform.position = GetComponent<Where>().Pole(-2, 0) + korekta;
                        FindObjectOfType<AudioManager>().Play("Ruch");
                        FindObjectOfType<GameManager>().iloscRuchow++;
                    }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                    if (tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Dzr" && tilemap.GetTile(GetComponent<Where>().Pole(2, 0)).name.Substring(0, 3) == "Pdl")
                    {
                        transform.position = GetComponent<Where>().Pole(2, 0) + korekta;
                        FindObjectOfType<AudioManager>().Play("Ruch");
                        FindObjectOfType<GameManager>().iloscRuchow++;
                    }
            }
        }
}
