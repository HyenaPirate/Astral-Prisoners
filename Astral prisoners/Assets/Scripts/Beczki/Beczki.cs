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
    void Start()
    {

    }
    void Awake()
    {
        gracze = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        for (int i = 0; i < gracze.Length; i++)
        {
            if (gracze[i] != null)
                if (gracze[i].GetComponent<Activate>().IsActive())
                {
                    if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[0].bounds))  //kiedy aktywny gracz stoi nad beczka
                        if(tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Dzr") //beczka niemoze byc na polu dziury aby zostac przesunieta
                            if (Input.GetKeyDown(KeyCode.DownArrow) && (tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(0, -1)).name.Substring(0, 3) == "Dzr")) //po wcisnieciu lewego controla sprawdza czy beczka bedzie przesunieta na pole podloza lub do dziury
                                transform.position = GetComponent<Where>().Pole(0, -1) + srodek; //przesuniecie beczki w do³

                    if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[1].bounds))  //kiedy aktywny gracz stoi pod beczka
                        if (tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Dzr")
                            if (Input.GetKeyDown(KeyCode.UpArrow) && (tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(0, 1)).name.Substring(0, 3) == "Dzr"))
                                transform.position = GetComponent<Where>().Pole(0, 1) + srodek; //przesuniecie beczki do gory

                    if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[2].bounds))  //kiedy aktywny gracz stoi na prawo od beczki
                        if (tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Dzr")
                            if (Input.GetKeyDown(KeyCode.LeftArrow) && (tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(-1, 0)).name.Substring(0, 3) == "Dzr"))
                                transform.position = GetComponent<Where>().Pole(-1, 0) + srodek; //przesuniecie beczki w lewo

                    if (gracze[i].GetComponent<Collider2D>().bounds.Intersects(GetComponents<Collider2D>()[3].bounds))  //kiedy aktywny gracz stoi na lewo od beczki
                        if (tilemap.GetTile(GetComponent<Where>().Pole(0, 0)).name.Substring(0, 3) != "Dzr")
                            if (Input.GetKeyDown(KeyCode.RightArrow) && (tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Pdl" || tilemap.GetTile(GetComponent<Where>().Pole(1, 0)).name.Substring(0, 3) == "Dzr"))
                                transform.position = GetComponent<Where>().Pole(1, 0) + srodek; //przesuniecie beczki w prawo

                }     
        }
        if (tilemap.GetTile(GetComponent<Where>().pos).name.Substring(0, 3) == "Dzr") //sprawdza czy beczka jest w dziurze
        {
            tilemap.SetTile(GetComponent<Where>().pos, pole); // podmienia pole na którym jest beczka
            Destroy(gameObject);  //niszczy beczke
        }
    }
}
