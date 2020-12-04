/*
GAME2014_A2_BARNES_ALEXANDER
flying_platform
controls flying platform making it go up and down to a set position using lerp, pingpong, and smoothstep
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class flying_platform : MonoBehaviour
{
    public Transform dest;
    private Vector3 start;
    private Vector3 end;
    private float secondsForOneLength = 5f;

    void Start()
    {
        start = transform.position;
        end = dest.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(start, end,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));
    }
}