using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hackable : MonoBehaviour
{
    /*
    Klasa abstrakcyjna
    Nie u¿ywaæ jako skryptu - unity nawet nie pozwoli
    Przy dodawaniu skryptu obiektu który ma byæ shackowany DZIEDZICZ po tej klasie zamiast MonoBehaviour
    Poniewa¿ ta klasa dziedziczy po MonoBehaviour to klasa dziedzicz¹ca po tej te¿ bêdzie wiêc nie ma sensu dziedziczyæ po obu
    Kiedy dziedziczysz po tej klasie zaimplementuj metodê hack

    ---------------------
    Dla przyk³adu u¿ycia sprawdŸ klasê Button
    ---------------------

    */ 
    abstract public void Hack();
}
