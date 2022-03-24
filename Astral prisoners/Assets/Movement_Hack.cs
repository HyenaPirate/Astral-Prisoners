using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_Hack : MonoBehaviour
{
    private GameObject[] hackable;
    private void Start()
    {
        hackable = GameObject.FindGameObjectsWithTag("Hack");
        
    }
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameIsPaused == false && GetComponent<Activate>().IsActive())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                for(int i = 0; i < hackable.Length; i++)
                {
                    Debug.Log("123");
                    if (hackable[i].transform.position == transform.position)
                    {
                        Debug.Log("A");
                        hackable[i].GetComponent<Hackable>().Hack();
                    }
                }
            }
        }
    }
}
