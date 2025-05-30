using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CountDownTimerChallenge : MonoBehaviour
{
    [SerializeField] float startTime;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject timeOver;

    float timer = 0f;
 
    public void BeginChronometer() { 
        if (gameObject.activeInHierarchy == true)
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("cronometro a correr");
            StartCoroutine(TimerEnum());
        }
    }

    private IEnumerator TimerEnum()
    {

        timer = startTime;
        do
        {
            timer -= Time.deltaTime;
      
            FormatText();

            yield return null;
        }
        while (timer > 0);

        //Se acabó el tiempo GAME OVER.
        timeOver.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void FormatText()
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