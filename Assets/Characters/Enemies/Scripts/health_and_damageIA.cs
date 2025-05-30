using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class health_and_damageIA : MonoBehaviour
{
    public float converted;
    public GameObject convertedBarUI;
    public Slider slider;
    public bool dosed = false;
    public GameObject[] savedPersons;
    public Text zombiesText;
    public static int zombiesCount;

    public GameObject finish;
    
    private void Start()
    {
        slider.maxValue = converted;
        slider.value = converted;
        slider.gameObject.SetActive(false);

        //CONTADOR MUTANTES DESAFIO
        if (GameObject.FindGameObjectWithTag("descriptionQuestChallenge") != null)
        {
            zombiesText = GameObject.FindGameObjectWithTag("descriptionQuestChallenge").GetComponent<Text>();
            zombiesText.text = "0/50";
            zombiesCount = 0;
        }

        if (GameObject.FindGameObjectWithTag("conseguido") != null)
        {
            finish = GameObject.FindGameObjectWithTag("conseguido");
            finish.GetComponent<Image>().enabled = false;
            finish.transform.GetChild(0).gameObject.SetActive(false);
            finish.transform.GetChild(1).gameObject.SetActive(false);
        }

    }
    public void TakeDose (float amount)
    {
        slider.gameObject.SetActive(true);
        if (slider.value > 0f)
        {
            dosed = true;
            slider.value -= amount;
        }

        if (slider.value <= 0)
        {
            personSaved();
        }
    }
    public void personSaved()
    {
        FindObjectOfType<savedPersonsArray>().choosePerson(gameObject);

        if (GameManager.manager != null)
        {
            //Contador modo historia
            if (gameObject.name == "BOSSfifthpatient" && GameManager.manager.zombiesCountBoss < 1)
            {
                GameManager.manager.zombiesCountBoss++;
                GameManager.manager.quest.goal.EnemyKilled();
                GameManager.manager.descriptionBoxExtra2.text = GameManager.manager.zombiesCountBoss + "/1   Quinto paciente sanado";
            }
            else if (GameManager.manager.zombiesCountNormal < 10)
            {
                GameManager.manager.zombiesCountNormal++;
                GameManager.manager.quest.goal.EnemyKilled();
                GameManager.manager.descriptionBoxExtra1.text = GameManager.manager.zombiesCountNormal + "/10   Mutantes sanados";
            }

            if (GameManager.manager.zombiesCountBoss + GameManager.manager.zombiesCountNormal >= 11)
            {
                GameManager.manager.descriptionBoxExtra1.enabled = false;
                GameManager.manager.descriptionBoxExtra2.enabled = false;
                GameManager.manager.descriptionBox.text = "Completado. Reúnete de nuevo con los científicos";
            }
            Destroy(gameObject);

        } //Contador modo desafio
        else if (zombiesCount == 49)
        {
            if (finish != null)
            {
                zombiesText.text = "50/50";
                gameObject.GetComponent<AudioSource>().Play();
                finish.GetComponent<Image>().enabled = true;
                finish.transform.GetChild(0).gameObject.SetActive(true);
                finish.transform.GetChild(1).gameObject.SetActive(true);
                finish.GetComponent<AudioSource>().Play();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0;
            }
        }
        else
        {
            zombiesCount++;
            zombiesText.text = zombiesCount + "/50";
            Destroy(gameObject);
        }
    }
}
