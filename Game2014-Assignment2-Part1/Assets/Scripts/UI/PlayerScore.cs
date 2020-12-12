/*
GAME2014_A2_BARNES_ALEXANDER
player score
saves players score
 LAST MODIFIED 12/11/2020
 VERSION 1.0.0
 */

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

}
