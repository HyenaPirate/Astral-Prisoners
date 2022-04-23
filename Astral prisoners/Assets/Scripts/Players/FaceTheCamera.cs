using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        transform.position += new Vector3(0, .3f, 0);
    }

    void Update() 
    {
        // Axis X and Y
        //transform.LookAt(2 * transform.position - Camera.main.transform.position);

        // Axis X only
        Vector3 targetPostition = new Vector3( this.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z ) ;
        this.transform.LookAt( targetPostition ) ;
        
    }


}