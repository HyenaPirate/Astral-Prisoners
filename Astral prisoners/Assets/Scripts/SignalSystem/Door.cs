using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    private Signals signals;
    public int lock_id; //na jaki sygna� maj� te drzwi reagowa�
    private Tilemap tilemap;
    public Tile tile; //na jaki tile ma si� zmieni� to co� pod drzwiami
    private void Awake()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        signals = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Signals>();
    }

    void Update()
    {
        if (signals.signal[lock_id]) //sprawdzam czy sygna� jest w��czony
        {
            tilemap.SetTile(GetComponent<Where>().pos,tile); //zmieniam tile pod drzwiami
            Destroy(gameObject); //zniszcz te drzwi
            Lampa.UpdateLight();
        }

    }
}
