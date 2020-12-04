/*
GAME2014_A2_BARNES_ALEXANDER
spike_platform
every 3.5 seconds the platform turns 180 degrees
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_platform : MonoBehaviour
{

    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (Time.frameCount % 350 == 0)
        {
            transform.Rotate(0.0f, 0.0f, 180.0f);
        }
    }
}
