using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject bonus;  
    public int chance;

    // Start is called before the first frame update
    void Start()
    {
        chance = Random.Range(1, 5);
        if(chance == 2)
        {
            Instantiate(bonus, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
  
}
