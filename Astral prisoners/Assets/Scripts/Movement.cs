using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
   public Tilemap tilemap;
   public GameObject player;
   Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
    void Update()
    {
        if(FindObjectOfType<GameManager>().gameIsPaused == false && player.GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.W) ) //gdy gracz jest aktywny i wcisnie "w"
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, 1)).name.Substring(0,7) == "Podloga")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(0, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, -1)).name.Substring(0, 7) == "Podloga")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(0, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 7) == "Podloga")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(-1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(1, 0)).name.Substring(0, 7) == "Podloga")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
        }
    }
}


/* BACKUP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
   public Tilemap tilemap;
   public GameObject player;
   Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
    void Update()
    {
        if(FindObjectOfType<GameManager>().gameIsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.W) && player.GetComponent<Activate>().IsActive()) //gdy gracz jest aktywny i wci�nie "w"
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, 1)).name != "Pustka")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(0, 1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.S) && player.GetComponent<Activate>().IsActive())
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, -1)).name != "Pustka")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(0, -1) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.A) && player.GetComponent<Activate>().IsActive())
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(-1, 0)).name != "Pustka")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(-1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
            if (Input.GetKeyDown(KeyCode.D) && player.GetComponent<Activate>().IsActive())
            {
                if (tilemap.GetTile(player.GetComponent<Where>().Pole(1, 0)).name != "Pustka")
                {
                    player.transform.position = player.GetComponent<Where>().Pole(1, 0) + korekta;
                    FindObjectOfType<AudioManager>().Play("Ruch");
                }
            }
        }
    }
}
*/