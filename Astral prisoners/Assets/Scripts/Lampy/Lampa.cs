using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lampa : MonoBehaviour
{
    public enum Rodzaj{normal,red}; //Stworzenie enuma Rodzaj
    public enum Kierunek {clockwise,anticlockwise }
    public Rodzaj rodzaj = Rodzaj.normal; //zadeklarowanie zmiennej typu Rodzaj
    public Kierunek kierunek = Kierunek.anticlockwise;
    public GameObject prefab;
    private Grid grid;
    private Tilemap tilemap;
    private bool reLight = false;
    Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
    void Start()
    {   
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        //pod tym przepisz Update():
         if(rodzaj == Rodzaj.normal)
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        if(rodzaj == Rodzaj.red)
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        if (kierunek == Kierunek.clockwise)
            transform.GetComponent<SpriteRenderer>().flipX = false;
        if (kierunek == Kierunek.anticlockwise)
            transform.GetComponent<SpriteRenderer>().flipX = true;
        Swiatlo();
    }
    void Update() 
    {
        if(rodzaj == Rodzaj.normal)
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        if(rodzaj == Rodzaj.red)
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        if (kierunek == Kierunek.clockwise)
            transform.GetComponent<SpriteRenderer>().flipX = false;
        if (kierunek == Kierunek.anticlockwise)
            transform.GetComponent<SpriteRenderer>().flipX = true;

        if (reLight)
        {
            Swiatlo();
            reLight = false;
        }
        
    }
    private void Swiatlo(int i = 1) //Wywolywac funkcje tylko dla i=1
    {
        if (i == 1) //tylko w pierwszej iteracji skryptu
        {
            Debug.Log(name + " " + GetComponent<Where>().Pole(0,0));
            //zabija wszystkie dzieci lampy
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (transform.rotation.eulerAngles.z == 0)
        {
            switch (tilemap.GetTile(GetComponent<Where>().Pole(0,i)).name.Substring(0, 3))
            {
                case "Pdl":
                case "Dzr":
                    //Jakby lampy mialy swiecic przez wiecej rzeczy, dodaj wiecej cas???w
                    GameObject pre = Instantiate(prefab, transform);
                    pre.transform.position = GetComponent<Where>().Pole(0, i) + korekta;
                    pre.transform.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
                    Swiatlo(i + 1);
                    break;
            }
        }

        if (transform.rotation.eulerAngles.z == 90)
        {
            switch (tilemap.GetTile(GetComponent<Where>().Pole(-i, 0)).name.Substring(0, 3))
            {
                case "Pdl":
                case "Dzr":
                    //Jakby lampy mialy swiecic przez wiecej rzeczy, dodaj wiecej cas???w
                    GameObject pre = Instantiate(prefab, transform);
                    pre.transform.position = GetComponent<Where>().Pole(-i, 0) + korekta;
                    pre.transform.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
                    Swiatlo(i + 1);
                    break;
            }
        }

        if (transform.rotation.eulerAngles.z == 180)
        {
            switch (tilemap.GetTile(GetComponent<Where>().Pole(0, -i)).name.Substring(0, 3))
            {
                case "Pdl":
                case "Dzr":
                    //Jakby lampy mialy swiecic przez wiecej rzeczy, dodaj wiecej cas???w
                    GameObject pre = Instantiate(prefab, transform);
                    pre.transform.position = GetComponent<Where>().Pole(0, -i) + korekta;
                    pre.transform.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
                    Swiatlo(i + 1);
                    break;
            }
        }

        if (transform.rotation.eulerAngles.z == 270)
        {
            switch (tilemap.GetTile(GetComponent<Where>().Pole(i, 0)).name.Substring(0, 3))
            {
                case "Pdl":
                case "Dzr":
                    //Jakby lampy mialy swiecic przez wiecej rzeczy, dodaj wiecej cas???w
                    GameObject pre = Instantiate(prefab, transform);
                    pre.transform.position = GetComponent<Where>().Pole(i, 0) + korekta;
                    pre.transform.GetComponent<SpriteRenderer>().color = transform.GetComponent<SpriteRenderer>().color;
                    Swiatlo(i + 1);
                    break;
            }
        }
    }

    public void RotateLamp()
    {
        if (kierunek == Kierunek.clockwise)
            transform.Rotate(new Vector3Int(0, 0, -90));
        else
            transform.Rotate(new Vector3(0, 0, 90));
        Swiatlo(1);
        FindObjectOfType<AudioManager>().Play("LampRotation");
    }
    public static void UpdateLight() //metoda statyczna, wywolaj ja jezeli chcesz aby swiatlo sie zaktualizowalo
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Lamp");
        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<Lampa>().reLight = true;
        }
    }
}

    