using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public bool gameIsPaused = true;

    public Grid grid;
    public Tilemap tilemap;
    public Exit exit;

    public int aktywnaPostac = 0; //0- Nikt nie jest aktywny. 1,2,3 - postaci. Dodatkowo sprite "aktywnosci" powinien byc jeden i teleportowac sie do aktywnego gracza, jesli go nie ma to znika.

    //Postaci powinny miec wlasne skrypty zawierajace pozycje 
    public Where postac1;
    public Where postac2;
    public Where postac3;


    public void Start()
    {
        exit.position = new Vector3Int(-2, 3, 0); //Te wartosci zczyta z pliku z informacjami o levelu
        //postac1.pos = new Vector3Int(-2, 3, 0);
        //postac2.pos = new Vector3Int(-2, 3, 0);
        //postac3.pos = new Vector3Int(-2, 3, 0);

        //tutaj bedzie spawnowal przeszkody zgodnie z podanymi w tym samym pliku instrukcjami.

        //-----------
        //Chociaz wiesz co, chuj wie. Bo w sumie to kazdy poziom bedzie swoja scena, to moze faktycznie nie ma sensu tego robic tylko dac wszystko od razu w unity jak ma byc a nie bawic sie we wczytywanie tego z pliku 
        //-----------

        gameIsPaused = false; //Odpauzowuje gre i pozwala graczowi na ruszanie postaciami, bo juz wszystko sie zaladowalo.
    }

    public void Update()
    {
        //tutaj dalbym funcje movementu, poniewaz nie potrzeba wszystkich graczy by sprawdzali czy sa aktywowani. Niech GameManager sprawdza input gracza i stosuje go do aktywowanej postaci.

        //if(aktywnaPostac != 0) aktywnaPostac.transform.position = movement

        //zmieni sie to pewnie kiedy i jesli zmienimy movement na klikanie, bo wtedy fajnie by bylo podswietlac kratki itp
    }

}
