using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hackable : MonoBehaviour
{
    /*
    Klasa abstrakcyjna
    Nie u�ywa� jako skryptu - unity nawet nie pozwoli
    Przy dodawaniu skryptu obiektu kt�ry ma by� shackowany DZIEDZICZ po tej klasie zamiast MonoBehaviour
    Poniewa� ta klasa dziedziczy po MonoBehaviour to klasa dziedzicz�ca po tej te� b�dzie wi�c nie ma sensu dziedziczy� po obu
    Kiedy dziedziczysz po tej klasie zaimplementuj metod� hack

    ---------------------
    Dla przyk�adu u�ycia sprawd� klas� Button
    ---------------------

    */ 
    abstract public void Hack();
}
