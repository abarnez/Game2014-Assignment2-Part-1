/*
GAME2014_A2_BARNES_ALEXANDER
flying_platform
controls flying platform making it going up and down to a set position using lerp and math f pingpong
found base code online and didnt have to tweak much
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class flying_platform : MonoBehaviour
{
    public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    private float secondsForOneLength = 5f;

   

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(frometh, untoeth,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));
    }
}