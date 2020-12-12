/*
GAME2014_A2_BARNES_ALEXANDER
bonus pickup
destorys itself and plays sound on collision with player
 LAST MODIFIED 12/11/2020
 VERSION 1.0.0
 */

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
