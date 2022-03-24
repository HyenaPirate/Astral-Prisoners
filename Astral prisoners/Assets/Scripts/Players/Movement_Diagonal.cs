using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_Diagonal : MonoBehaviour
{
    Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
    public Tilemap tilemap;
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameIsPaused == false && GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(-1, 1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(-1, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(1, 1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(1, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(-1, -1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(-1, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(1, -1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(1, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
        }
    }
}
