﻿/* 
 Alexander Barnes 101086806
 GAME2014_A2_BARNES_ALEXANDER
 BUTTON_MANAGER
 SCRIPT USED TO CHANGE SCENES AFTER BUTTON ONCLICK EVENT IS CALLED WITH PUBLIC STRING FIELD SO YOU CAN TYPE NAME OF SCENE YOU WANT
 IN EDITOR, CURRENTLY SET UP FOR ONLY TWO BUTTONS AS NONE OF MY SCENES HAVE MORE THAN 2 BUTTONS
 also plays sound on click
 LAST MODIFIED 11/5/2020
 VERSION 1.0.1
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public Button StartButton;
    public Button InstructButton;
    public string scene1;
    public string scene2;
    public AudioSource clickSound;

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(clickSound.clip.length);
        SceneManager.LoadScene(scene1);
    }

    IEnumerator DelaySceneLoad2()
    {
        yield return new WaitForSeconds(clickSound.clip.length);
        SceneManager.LoadScene(scene2);
    }


    void Start()
    {
        Button btn = StartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button btn2 = InstructButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

      
    }
    void TaskOnClick()
    {
        clickSound.Play();
      
       // SceneManager.LoadScene(scene1);
        StartCoroutine(DelaySceneLoad());


    }
    void TaskOnClick2()
    {
        clickSound.Play();
        StartCoroutine(DelaySceneLoad2());

    }

}