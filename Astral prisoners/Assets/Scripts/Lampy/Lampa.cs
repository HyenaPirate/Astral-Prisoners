using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lampa : MonoBehaviour
{
    private int idLampy;
    private static int idGiver = 0;
    public GameObject prefab;
    public Grid grid;
    public Tilemap tilemap;
    Vector3 korekta = new Vector3(0.5f, 0.5f, 0);
    void Start()
    {
        GetComponent<Where>().Update(); //Kolejnosc wykonywania skryptow, psola to
        idLampy = idGiver;
        idGiver++;
        Swiatlo(1);
    }
    private void Swiatlo(int i) //Wywolywac funkcje tylko dla i=1
    {
        if (i == 1) //tylko w pierwszej iteracji skryptu
        {
            //zabija wszystkie dzieci lampy
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (transform.rotation.z == 0)
        {
            switch (tilemap.GetTile(GetComponent<Where>().Pole(0,i)).name.Substring(0, 3))
            {
                case "Pdl":
                case "Dzr":
                    //Jakby lampy mialy swiecic przez wiecej rzeczy, dodaj wiecej casów
                    GameObject pre = Instantiate(prefab, transform);
                    pre.transform.position = GetComponent<Where>().Pole(0, i) + korekta;
                    Swiatlo(i + 1);
                    break;
            }
        }
    }
}
