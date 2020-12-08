using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Final Score: " + PlayerPrefs.GetFloat("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
