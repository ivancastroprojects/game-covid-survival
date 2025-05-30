using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject player;
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Button buttonTalk;
    private bool onlyOneTime;

    public Camera NPCcam;
    public CameraFollow cam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        buttonTalk.gameObject.SetActive(false);
        onlyOneTime = false;

        cam = FindObjectOfType<CameraFollow>();
    }
    private void Update()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > 1.3f && !onlyOneTime)
        {
            cam.canMoveCam(true);

            onlyOneTime = true;
            buttonTalk.gameObject.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(dist < 1.3f)
        {
            onlyOneTime = false;
            cam.canMoveCam(false); //revisar, igual no necesario
            buttonTalk.gameObject.SetActive(true);
        
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //FindObjectOfType<DialogueManager>().dialogueOrNote.gameObject.activeInHierarchy)

        if (dist < 1.5 && NPCcam.GetComponentInParent<DialogueManager>().dialogueOrNote.gameObject.activeInHierarchy)
        {
            buttonTalk.gameObject.SetActive(false);
        }
    }
    public void TriggerDialogue()
    {
        buttonTalk.gameObject.SetActive(false);

        //switch off the main camera, switch on the NPC camera
        NPCcam.gameObject.SetActive(true);
        FindObjectOfType<CameraFollow>().enabled = false;

        //switch off the player and his control
        if (GameManager.manager.GetToTextQuest() == "Héroe sin capa" && gameObject.name == "Director")
        {
            GameManager.manager.quest.Complete(GameManager.manager.quest);
            GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        }
        else
        {
            FindObjectOfType<MainController>().enabled = false;
            player.SetActive(false);
        }
        
        if (GameManager.manager.GetToTextQuest() == "Sin luz y sin defensas" && GameManager.manager.quest.complete)
        {
            Debug.Log("Misión 4 completada");
            NPCcam.GetComponentInParent<DialogueManager>().StartDialogue(dialogue2, gameObject, NPCcam);
        } 
        else if (GameManager.manager.GetToTextQuest() == "Acaba con la mutación" && GameManager.manager.quest.complete)
        {
            Debug.Log("Misión 5 completada. Escena final.");
            NPCcam.GetComponentInParent<DialogueManager>().StartDialogue(dialogue3, gameObject, NPCcam);
        }
        else
        {
            NPCcam.GetComponentInParent<DialogueManager>().StartDialogue(dialogue, gameObject, NPCcam);
            Debug.Log("Misión 1, 2 o 3 o última iniciada");
        }
    }
    
}
