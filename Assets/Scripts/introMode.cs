using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class introMode : MonoBehaviour
{
    public GameObject introMenu;
    public GameObject controls;
    public GameObject tittleLevel;
    public GameObject chronometer;

    public GameObject textChallengeMode;
    public GameObject rememberQuest;
    public Image barraDeVida;
    public Image imageDamage;
    public static Color temp;    

    void Start()
    {
        //Menú introducción
        if (GameManager.manager != null) //HISTORIA
        {
            if (!GameManager.manager.onlyOneTimeIntro)
            {
                GameManager.manager.onlyOneTimeIntro = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (introMenu != null)
                    introMenu.SetActive(true);
            }
            else
            {
                if (introMenu != null)
                    introMenu.SetActive(false);
            }
        }
        else //DESAFIO
        {
            if (SceneManager.GetActiveScene().name == "CHALLENGE MODE")
            {
                introMenu.SetActive(true);
            }
            else ExitControlWindow();

            if (tittleLevel != null)
                tittleLevel.SetActive(false);

            if (SceneManager.GetActiveScene().name == "CHALLENGE MODE")
            {
                introMenu.SetActive(true);
            }
            else ExitControlWindow();

            if (textChallengeMode != null)
                textChallengeMode.SetActive(false);

            rememberQuest = GameObject.Find("/Canvas/RememberQuest");

            if (rememberQuest != null)
                rememberQuest.SetActive(false);
        }
    }

    public void ExitIntroWindow()
    {
        introMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void ExitControlWindow()
    {
        controls.SetActive(false);

        if(GameManager.manager == null && !gameObject.GetComponent<pause>().pauseMenuUI.activeInHierarchy) //DESAFIO
        {
            StartCoroutine(TimeTittle());
            tittleLevel.SetActive(true);
            tittleLevel.GetComponent<AudioSource>().Play();
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
    }

    private IEnumerator TimeTittle()
    {
        if (textChallengeMode != null)
            textChallengeMode.SetActive(true);

        yield return new WaitForSeconds(3);
        if (tittleLevel != null)
        {
            tittleLevel.SetActive(false);
        }
        chronometer.SetActive(true);
        chronometer.GetComponent<CountDownTimer>().BeginChronometer();
        
        if(rememberQuest != null)
            rememberQuest.SetActive(true);

        if (textChallengeMode != null)
            textChallengeMode.SetActive(true);
    }
}
