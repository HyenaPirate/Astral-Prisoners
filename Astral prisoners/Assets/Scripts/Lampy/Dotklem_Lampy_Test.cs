using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dotklem_Lampy_Test : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<Lampa>())
        {
            Debug.Log(collision.gameObject.GetComponentInParent<Transform>().parent.name);
        }
    }
}
