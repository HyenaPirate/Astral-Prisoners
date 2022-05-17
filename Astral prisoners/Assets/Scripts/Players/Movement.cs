using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Movement : MonoBehaviour
{
   protected Tilemap tilemap;
   protected Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
   //public bool wRuchu = false;
   //public GameManager gameManager;

    protected void Awake()
    {
        tilemap = GameObject.FindWithTag("Tilemap").GetComponent<Tilemap>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    /*
    IEnumerator CreateDelay(float time)
    {
        yield return new WaitForSeconds(time);
    }*/
    abstract public void MoveCharacter();
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameIsPaused == false && GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.W) && tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Pdl")
            {
                transform.position = GetComponent<Where>().Pole(0, 1) + korekta;
                //wRuchu = true;
                //StartCoroutine(CreateDelay(2f));
                //GetComponent<Delayer>().CreateDelay(5f);
                FindObjectOfType<AudioManager>().Play("Ruch");
                FindObjectOfType<GameManager>().iloscRuchow++;
                //wRuchu = false;
            }
            else if (Input.GetKeyDown(KeyCode.S) && tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Pdl")
            {
                transform.position = GetComponent<Where>().Pole(0, -1) + korekta;
                FindObjectOfType<AudioManager>().Play("Ruch");
                FindObjectOfType<GameManager>().iloscRuchow++;
            }
            else if (Input.GetKeyDown(KeyCode.A) && tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Pdl")
            {
                transform.position = GetComponent<Where>().Pole(-1, 0) + korekta;
                FindObjectOfType<AudioManager>().Play("Ruch");
                FindObjectOfType<GameManager>().iloscRuchow++;
            }
            else if (Input.GetKeyDown(KeyCode.D) && tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Pdl")
            {
                transform.position = GetComponent<Where>().Pole(1, 0) + korekta;
                FindObjectOfType<AudioManager>().Play("Ruch");
                FindObjectOfType<GameManager>().iloscRuchow++;
            }
            else this.MoveCharacter(); //jezeli normalny movement nie zadziala uzyj movementu konkretnej postaci
        }
    }
}
