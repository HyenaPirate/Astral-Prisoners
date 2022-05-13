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
        Debug.Log("Kolizja1");
        if (collision.transform.CompareTag("LampLight"))
        {
            Debug.Log("kolizja2");
               if(collision.gameObject.GetComponentInParent<Lampa>().rodzaj == Lampa.Rodzaj.normal && dead_by_normal)
                {
                    gameManager.GameOver();
                }
                if (collision.gameObject.GetComponentInParent<Lampa>().rodzaj == Lampa.Rodzaj.red && dead_by_red)
                {
                Debug.Log("kolizja3");
                    gameManager.GameOver();
                }
        }
    }

}
