using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class kolorSwiatla : MonoBehaviour
{
    void Start()
    {
        transform.GetComponent<Light2D>().color = transform.GetComponent<SpriteRenderer>().color;
    }
}
