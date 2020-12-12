/*
GAME2014_A2_BARNES_ALEXANDER
enemy projectile
moves game object to the right
 LAST MODIFIED 11/16/2020
 VERSION 1.0.0
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //transform.right += new Vector3(speed, 0.0f);
        rb.velocity = transform.right * speed;
    }

 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Destroy(gameObject);
        }
    }
}
