/*
GAME2014_A2_BARNES_ALEXANDER
turn_platform
every 5.5 seconds the platform turns 90 degrees
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_platform : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Rotate();
    }



    public void Rotate()
    {
        if (Time.frameCount % 550 == 0) {
            transform.Rotate(0.0f, 0.0f, 90.0f);
                }
    }
}
