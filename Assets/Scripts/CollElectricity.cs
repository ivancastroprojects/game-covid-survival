using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollElectricity : MonoBehaviour
{
    public GameObject buttonElectricity;
    public GameObject lights;
    bool onlyOneTime;
    private void Start()
    {
        lights = GameObject.FindGameObjectWithTag("Lights");
        buttonElectricity = GameObject.Find("Canvas/ButtonsTalk/ButtonElectricity");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameManager.manager.descriptionBoxExtra1.text == "0/1   Activa la corriente del MIC")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            buttonElectricity.SetActive(true);

            buttonElectricity.GetComponent<Button>().onClick.AddListener(() => GameManager.manager.quest.goal.ItemCollected());
            Debug.Log("pulsado");
            Debug.Log(GameManager.manager.quest.goal.currentAmount);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        buttonElectricity.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
