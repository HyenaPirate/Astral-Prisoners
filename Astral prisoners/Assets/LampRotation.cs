using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampRotation : MonoBehaviour
{
    GameObject[] players;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    private void Update()
    {
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i] != null)
            if (players[i].GetComponent<Activate>().IsActive())
                if (players[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[0].bounds) || players[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[1].bounds))
                    if(Input.GetKeyDown(KeyCode.Space))
                        GetComponent<Lampa>().RotateLamp();
        }
    }
}
