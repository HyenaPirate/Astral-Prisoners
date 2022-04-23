using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
   public Tilemap tilemap;
   Vector3 korekta = new Vector3(0.5f, 0.5f, 0);

    void Start()
    {
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
    }

    void Update()
    {
        if(FindObjectOfType<GameManager>().gameIsPaused == false && GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.W) ) //gdy gracz jest aktywny i wcisnie "w"
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0,3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(0, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(0, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(-1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                }
            }
        }
    }
}
