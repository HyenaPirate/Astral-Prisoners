using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Dead : MonoBehaviour
{
    public bool dead_by_normal;
    public bool dead_by_red;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("LampLight"))
        {
               if(collision.gameObject.GetComponentInParent<Lampa>().rodzaj == Lampa.Rodzaj.normal && dead_by_normal)
               {
                    gameManager.GameOver();
               }
               if (collision.gameObject.GetComponentInParent<Lampa>().rodzaj == Lampa.Rodzaj.red && dead_by_red)
               {
                    gameManager.GameOver();
               }
        }
    }

}
