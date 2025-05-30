using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] float startTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject timeOver;

    float timer;
    bool onlyOneTime;
    public void Start()
    {
        if (GameManager.manager != null) //HISTORIA
        {
            if (GameManager.manager.GetToTextQuest() == "Sin luz y sin defensas")
            {
                timeOver = GameObject.Find("Canvas/TextEndTime");
                BeginChronometer();
            }
        }
        else
        {    
            timeOver = GameObject.Find("Canvas/TextEndTime");
            timeOver.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void BeginChronometer() {
        if (gameObject.activeInHierarchy == true)
        {
            if (GameManager.manager != null || (GameManager.manager == null && !onlyOneTime))
            {
                onlyOneTime = true;

                gameObject.GetComponent<AudioSource>().Play();
                Debug.Log("cronometro a correr");
                StartCoroutine(TimerEnum());
            }
        }
    }
    public void changetimer()
    {
        GameManager.manager.timer = 300;
    }
    private IEnumerator TimerEnum()
    {
        if (GameManager.manager != null) //HISTORIA
        {
            GameManager.manager.startTime = timer;
            do
            {
                GameManager.manager.timer -= Time.deltaTime;

                FormatText();

                yield return null;
            }
            while (GameManager.manager.timer > 0);
        }
        else //DESAFIO
        {
            timer = startTime;
            do
            {
                timer -= Time.deltaTime;

                FormatTextChallenge();

                yield return null;
            }
            while (timer > 0);
        }

        //Se acabó el tiempo GAME OVER.
        if (timeOver == null)
        {
            timeOver = GameObject.Find("Canvas/TextEndTime");
        }

        timeOver.SetActive(true);

        if(GameManager.manager != null)
            GetComponent<Health_and_Damage>().GameOverTime();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void FormatText()
    {
        int minutes = (int)(GameManager.manager.timer / 60) % 60;
        int seconds = (int)(GameManager.manager.timer % 60);

        timerText.text = "";
        if (minutes >= 0)
        {
            if (minutes < 10)
                timerText.text += "0" + minutes + " : ";
            else timerText.text += minutes + " : ";
           
        }
        if (seconds >= 0)
        {
            if (seconds < 10)
                timerText.text += "0" + seconds;
            else timerText.text += seconds;   
        }
    }
    private void FormatTextChallenge()
    {
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);

        timerText.text = "";
        if (minutes >= 0)
        {
            if (minutes < 10)
                timerText.text += "0" + minutes + " : ";
            else timerText.text += minutes + " : ";

        }
        if (seconds >= 0)
        {
            if (seconds < 10)
                timerText.text += "0" + seconds;
            else timerText.text += seconds;
        }
    }
}