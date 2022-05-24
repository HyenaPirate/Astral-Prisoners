using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScheme : MonoBehaviour
{
    private static Color[] colors = {
        new Color(173/255f, 17/255f, 17/255f), //szkarlatnt - czerwony
        new Color(0/255f, 64/255f, 128/255f),  //blekit pruski - niebieski
        new Color(128/255f, 128/255f, 0/255f), //oliwkowy - zielony
        new Color(230/255f, 28/255f, 102/255f), //amarantowy - rozowy
        new Color(180/255f,180/255f,190/255f) //szary
    };

    public static Color GetColor(int id)
    {
        return colors[id];
    }
}
