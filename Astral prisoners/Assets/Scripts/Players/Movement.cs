using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
   public Tilemap tilemap;
   Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
   //public bool wRuchu = false;
   //public GameManager gameManager;

    void Start()
    {

        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    /*
    IEnumerator CreateDelay(float time)
    {
        yield return new WaitForSeconds(time);
    }*/

    void Update()
    {
        if(FindObjectOfType<GameManager>().gameIsPaused == false && GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.W) ) //gdy gracz jest aktywny i wcisnie "w"
            {
                if (tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0,3) == "Pdl")
                {
                    transform.position = GetComponent<Where>().Pole(0, 1) + korekta;
                    //wRuchu = true;
                    //StartCoroutine(CreateDelay(2f));
                    //GetComponent<Delayer>().CreateDelay(5f);
                    FindObjectOfType<AudioManager>().Play("Ruch");
                    FindObjectOfType<GameManager>().iloscRuchow++;
                    
                    //wRuchu = false;
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
