using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacuneCorrect : MonoBehaviour
{
    public GameObject activateVacune;
  
    public void OnTriggerEnter(Collider other)
    {
        activateVacune = GameObject.Find("Canvas/ButtonsTalk/ButtonVacune");
        Debug.Log(GameManager.manager.GetToTextQuest());
        
        if (other.tag == "Player" && GameManager.manager.GetToTextQuest()=="Sin luz y sin defensas")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            activateVacune.GetComponent<Button>().enabled = true;
            activateVacune.GetComponent<Image>().enabled = true;
            activateVacune.GetComponentInChildren<Text>().text = "Coger vacuna";
            activateVacune.GetComponent<Button>().onClick.AddListener(ripVacune);
            Debug.Log(GameManager.manager.GetToTextQuest());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        activateVacune.GetComponent<Button>().enabled = false;
        activateVacune.GetComponent<Image>().enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ripVacune()
    {
        GameManager.manager.quest.goal.ItemCollected();
        GameManager.manager.descriptionBoxExtra2.text = "1/1   Coge la vacuna del laboratorio";
        Debug.Log("Vacuna recogida");
        Destroy(gameObject);
        activateVacune.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
