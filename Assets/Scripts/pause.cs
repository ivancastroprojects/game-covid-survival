using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    private static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject textChallengeMode;
    public GameObject rememberQuest;
    public GameObject chronometer;
    public GameObject imageDamage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Comprobamos si estamos en pausa o no
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if (GameObject.Find("/Canvas/windowHistoria"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.Escape) && GameObject.FindGameObjectWithTag("video"))
            GameObject.FindGameObjectWithTag("video").SetActive(false);
    }

    public void Resume()
    {
        if (textChallengeMode != null)
            textChallengeMode.SetActive(true);

        if (rememberQuest != null)
            rememberQuest.SetActive(true);

        if (chronometer != null && GameManager.manager == null)
            chronometer.transform.position -= new Vector3(0, 200, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (GameManager.manager == null)
        {
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(3).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(4).gameObject.SetActive(true);
            imageDamage.SetActive(true);
        }
        else GameManager.manager.imageDamage.enabled = true;

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (GameManager.manager == null)
        {
            if (textChallengeMode == null)
            {
                textChallengeMode = GameObject.Find("/Canvas/textChallengeMode");
            }
            textChallengeMode.SetActive(false);

            if (rememberQuest == null)
            {
                rememberQuest = GameObject.Find("/Canvas/RememberQuest");
                rememberQuest.SetActive(false);
            }
            rememberQuest.SetActive(false);

            if (chronometer == null)
            {
                chronometer = GameObject.Find("/Canvas/Chronometer");
            }

            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("mainInterface").transform.GetChild(4).gameObject.SetActive(false);


            chronometer.transform.position += new Vector3(0, 200, 0);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameManager.manager == null)
            imageDamage.SetActive(false);
        else GameManager.manager.imageDamage.enabled = false;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Salir(string scenename)
    {
        if (scenename == "MENU")
        {
            Destroy(GameObject.Find("/GameManager"));
            Destroy(GameObject.Find("/QuestGiver"));
            Destroy(GameObject.Find("/Characters"));

            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(scenename);
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(scenename);
        }
    }
}