using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayer : MonoBehaviour
{
    float startTime;
    public void CreateDelay(float delay)
    {
        startTime = Time.deltaTime;

        while(Time.deltaTime < startTime + delay%60)
        {
            Debug.Log("Delaying...");
        }
        Debug.Log("Delay Done.");
    }
}
