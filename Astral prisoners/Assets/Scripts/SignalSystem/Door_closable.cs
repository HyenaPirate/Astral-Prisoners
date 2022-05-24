using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door_closable : MonoBehaviour
{
    private Signals signals;
    public int lock_id; //na jaki sygna³ maj¹ te drzwi reagowaæ
    private Tilemap tilemap;
    public Tile tileOpen; //na jaki tile ma siê zmieniæ to coœ pod drzwiami przy otwieraniu
    public Tile tileClose; //na jaki tile ma siê zmieniæ to coœ pod drzwiami przy zamykaniu
    private SpriteRenderer spriteRenderer;
    public Sprite on;
    private Sprite off;
    private bool state = false;
    public bool isInverted; //Czy drzwi dzialaja w trybie odwroconym
    private void Awake()
    {
        tilemap = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<Tilemap>();
        signals = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Signals>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        transform.GetComponent<SpriteRenderer>().color = ColorScheme.GetColor(lock_id);
        off = spriteRenderer.sprite;
    }

    void Update()
    {
        if ( (signals.signal[lock_id] != isInverted) && !state  ) 
        {
            tilemap.SetTile(GetComponent<Where>().pos, tileOpen);
            Lampa.UpdateLight();
            spriteRenderer.sprite = on;
            state = true;
        }
        else if( (!signals.signal[lock_id] != isInverted) && state)
        {
            tilemap.SetTile(GetComponent<Where>().pos, tileClose);
            Lampa.UpdateLight();
            spriteRenderer.sprite = off;
            state = false;
        }

    }
}
