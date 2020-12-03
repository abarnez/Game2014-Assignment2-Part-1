using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool canShoot;
    public GameObject bullet;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            Shoot();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);

        if (other.tag == "Player")
        {
            if (other.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }

            if (other.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            Debug.Log("I see player");
            canShoot = true;
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);

        if (other.tag == "Player")
        {
         
            Debug.Log("I cant see player");
            canShoot = false;
        }

    }

    public void Shoot()
    {
        if(Time.frameCount % 550 == 0)
        {
            Instantiate(bullet, firePoint.transform.position, transform.rotation);
            bullet.transform.right = transform.right.normalized;
        }
    }
}
