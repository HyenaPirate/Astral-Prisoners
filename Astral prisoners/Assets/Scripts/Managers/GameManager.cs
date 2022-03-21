using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused = true;
    public GameObject aktywnosc;

    public void Start()
    {
        gameIsPaused = false; //Odpauzowuje gre i pozwala graczowi na ruszanie postaciami, bo juz wszystko sie zaladowalo.
    }
    public void Update()
    {
        GameObject postac = Activate.GetActivePlayer(); //Pobieram aktywnego gracza
        if (postac != null)
        {
            aktywnosc.transform.position = postac.transform.position;
            aktywnosc.SetActive(true);
        }
        else
        {
            aktywnosc.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && gameIsPaused == false)
        {
            FindObjectOfType<MenuInterface>().ReloadScene();
        }
    }
}
