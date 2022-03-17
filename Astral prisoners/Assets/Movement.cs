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
        if (Input.GetKeyDown(KeyCode.W) && player.GetComponent<Activate>().GetActivePlayer()) //gdy gracz jest aktywny i wciœnie "w"
        {
            if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, 1)).name != "Pustka")
            {
                player.transform.position = player.GetComponent<Where>().Pole(0, 1) + korekta;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && player.GetComponent<Activate>().GetActivePlayer())
        {
            if (tilemap.GetTile(player.GetComponent<Where>().Pole(0, -1)).name != "Pustka")
            {
                player.transform.position = player.GetComponent<Where>().Pole(0, -1) + korekta;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && player.GetComponent<Activate>().GetActivePlayer())
        {
            if (tilemap.GetTile(player.GetComponent<Where>().Pole(-1, 0)).name != "Pustka")
            {
                player.transform.position = player.GetComponent<Where>().Pole(-1, 0) + korekta;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && player.GetComponent<Activate>().GetActivePlayer())
        {
            if (tilemap.GetTile(player.GetComponent<Where>().Pole(1, 0)).name != "Pustka")
            {
                player.transform.position = player.GetComponent<Where>().Pole(1, 0) + korekta;
            }
        }
    }
}
