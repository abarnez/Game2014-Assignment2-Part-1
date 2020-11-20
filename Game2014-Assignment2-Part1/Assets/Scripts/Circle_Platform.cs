/*
GAME2014_A2_BARNES_ALEXANDER
Circle_Platform
moves the platform in a circular motion
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Platform : MonoBehaviour
{

    private float Speed = 1f;
    private float Radius = 1.0f;
    private Vector2 centre;
    private float angle;

    private void Start()
    {
        centre = transform.position;
    }

    private void Update()
    {
        angle += Speed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;
    }
}
