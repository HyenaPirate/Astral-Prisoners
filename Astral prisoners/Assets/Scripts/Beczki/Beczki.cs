using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Beczki : MonoBehaviour
{
    public GameObject[] gracze;
    public Tilemap tilemap;
    public Tile pole;
    Vector3 srodek = new Vector3(0.5f, 0.5f, 0);
    public GameObject manager;
    int cofnij,cofnij2;
    public GameObject[] beczki;
    bool inna_beczka;
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
    }
    void Awake()
    {
        gracze = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        beczki = GameObject.FindGameObjectsWithTag("Beczka");
        for (int i = 0; i < gracze.Length; i++)
        {
            if (gracze[i] != null)
            {
                if (gracze[i].GetComponent<Activate>().IsActive())
                {
                    if (tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Dzr") //beczka niemoze byc na polu dziury aby zostac przesunieta
                    {
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[0].bounds))  //kiedy aktywny gracz stoi nad beczka
                        {
                            cofnij = 0;
                            cofnij2 = 1;
                            if (gracze[i].GetComponent<Activate>().IsActive() && Input.GetKeyDown(KeyCode.S) && (tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Dzr")) // sprawdza czy beczka bedzie przesunieta na pole podloza lub do dziury
                            {
                                inna_beczka = false;
                                for (int j = 0; j < beczki.Length; j++)
                                {
                                    if (GetComponent<Where>().Pole(0, -1) == beczki[j].GetComponent<Where>().Pole(0, 0))
                                    {
                                        inna_beczka = true;
                                        break;
                                    }
                                }
                                if (inna_beczka == false)
                                {
                                    transform.position = GetComponent<Where>().Pole(0, -1) + srodek; //przesuniecie beczki w do³
                                }
                            }
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[1].bounds))  //kiedy aktywny gracz stoi pod beczka
                        {
                            cofnij = 0;
                            cofnij2 = -1;
                            if (Input.GetKeyDown(KeyCode.W) && (tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Dzr"))
                            {
                                inna_beczka = false;
                                for (int j = 0; j < beczki.Length; j++)
                                {
                                    if (GetComponent<Where>().Pole(0, 1) == beczki[j].GetComponent<Where>().Pole(0, 0))
                                    {
                                        inna_beczka = true;
                                        break;
                                    }
                                }
                                if (inna_beczka == false)
                                {
                                    transform.position = GetComponent<Where>().Pole(0, 1) + srodek; //przesuniecie beczki do gory
                                }
                            }
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[2].bounds))  //kiedy aktywny gracz stoi na prawo od beczki
                        {
                            cofnij = 1;
                            cofnij2 = 0;
                            if (Input.GetKeyDown(KeyCode.A) && (tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Dzr"))
                            {
                                inna_beczka = false;
                                for (int j = 0; j < beczki.Length; j++)
                                {
                                    if (GetComponent<Where>().Pole(-1, 0) == beczki[j].GetComponent<Where>().Pole(0, 0))
                                    {
                                        inna_beczka = true;
                                        break;
                                    }
                                }
                                if (inna_beczka == false)
                                {
                                    transform.position = GetComponent<Where>().Pole(-1, 0) + srodek; //przesuniecie beczki w lewo
                                }
                            }
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[3].bounds))  //kiedy aktywny gracz stoi na lewo od beczki
                        {
                            cofnij = -1;
                            cofnij2 = 0;
                            if (Input.GetKeyDown(KeyCode.D) && (tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Dzr"))
                            {
                                inna_beczka = false;
                                for (int j = 0; j < beczki.Length; j++)
                                {
                                    if (GetComponent<Where>().Pole(1, 0) == beczki[j].GetComponent<Where>().Pole(0, 0))
                                    {
                                        inna_beczka = true;
                                        break;
                                    }
                                }
                                if (inna_beczka == false)
                                {
                                    transform.position = GetComponent<Where>().Pole(1, 0) + srodek; //przesuniecie beczki w prawo
                                }
                            }
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[5].bounds))  //kiedy aktywny gracz stoi na ukos gora lewo od beczki
                        {
                            cofnij = -1;
                            cofnij2 = 1;
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[6].bounds))  //kiedy aktywny gracz stoi na ukos gora prawo od beczki
                        {
                            cofnij = 1;
                            cofnij2 = 1;
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[7].bounds))  //kiedy aktywny gracz stoi na ukos dol lewo od beczki
                        {
                            cofnij = -1;
                            cofnij2 = -1;
                        }
                        if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[8].bounds))  //kiedy aktywny gracz stoi na ukos dol prawo od beczki
                        {
                            cofnij = 1;
                            cofnij2 = -1;
                        }
                    }
                }
                if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[4].bounds))  //kiedy gracz anajdzie sie na polu z beczka
                    gracze[i].transform.position = GetComponent<Where>().Pole(cofnij, cofnij2) + srodek;
            }
        }
        if (manager.GetComponent<GameManager>().iloscRuchow > 0)
        {
            if (tilemap.GetTile(GetComponent<Where>().pos).name.Substring(0, 3) == "Dzr") //sprawdza czy beczka jest w dziurze
            {
                tilemap.SetTile(GetComponent<Where>().pos, pole); // podmienia pole na którym jest beczka
                Destroy(gameObject);  //niszczy beczke
            }
        }
    }
}
