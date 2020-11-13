using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike_platform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
