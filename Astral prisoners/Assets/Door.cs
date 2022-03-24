using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    private Signals signals;
    public int lock_id; //na jaki sygna³ maj¹ te drzwi reagowaæ
    public Tilemap tilemap;
    public Tile tile; //na jaki tile ma siê zmieniæ to coœ pod drzwiami
    private void Start()
    {
        signals = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Signals>();
    }

    void Update()
    {
        if (signals.signal[lock_id]) //sprawdzam czy sygna³ jest w³¹czony
        {
            tilemap.SetTile(GetComponent<Where>().pos,tile); //zmieniam tile pod drzwiami
            Destroy(gameObject); //zniszcz te drzwi
        }

    }
}
