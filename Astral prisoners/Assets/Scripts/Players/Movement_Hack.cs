using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_Hack : Movement
{
    private GameObject[] hackable;
    new private void Awake() //przeci��am awake() z klasy Movement
    {
        base.Awake(); //uruchamiam bazowego awake()
        hackable = GameObject.FindGameObjectsWithTag("Hack");
    }
    override public void MoveCharacter()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < hackable.Length; i++)
                {
                    if (hackable[i].transform.position == transform.position)
                    {
                        hackable[i].GetComponent<Hackable>().Hack();
                        FindObjectOfType<AudioManager>().Play("Hack");
                        animator.Play("Hack1");
                        FindObjectOfType<GameManager>().iloscRuchow++;
                    }
                }
            }
    }
}
