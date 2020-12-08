using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPickup : MonoBehaviour
{

    public AudioSource coin;

    IEnumerator DelayObjectDestroy()
    {
        yield return new WaitForSeconds(coin.clip.length);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
  

    // Update is called once per frame
  

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            coin.Play();
            gameObject.GetComponent<Renderer>().enabled = false;
            StartCoroutine(DelayObjectDestroy());
        }
    }
}
