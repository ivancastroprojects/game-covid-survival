using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text extraInformation;
    public Text description;

    public GameObject dialogueOrNote;
    public GameObject continueDialogue, continueDialogue2, continueDialogue3;

    public GameObject acceptQuest;
    public Queue<string> sentences;

    private GameObject thisNPC;
    private Camera thisNPCcam;
    private Dialogue thisDialogue;

    public GameObject camGuard1, camGuard2, camGuard3, camGuard4, camGuard5, camMain1, camDir1, camDir2, camDir3;
    public Animator anim;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueOrNote.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue, GameObject NPC, Camera NPCcam)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //GameObject.FindGameObjectWithTag("mainInterface").SetActive(false);

        GameManager.manager.interfaceDisplay.SetActive(false);

        thisNPC = NPC;
        thisNPCcam = NPCcam;
        thisDialogue = dialogue;

        dialogueOrNote.SetActive(true);
        if(NPC.name == "guardscientist")
        {
            continueDialogue.SetActive(true);
            continueDialogue2.SetActive(false);
            continueDialogue3.SetActive(false);
        }
        else if(NPC.name == "mainscientist")
        {
            continueDialogue.SetActive(false);
            continueDialogue2.SetActive(true);
            continueDialogue3.SetActive(false);
        }
        else //director
        {
            continueDialogue.SetActive(false);
            continueDialogue2.SetActive(false);
            continueDialogue3.SetActive(true);
        }

        acceptQuest.SetActive(false);
        nameText.text = dialogue.name;
        extraInformation.text = dialogue.extraInformation;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
            DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        /**Debug.Log(sentences.Count);
        Debug.Log(thisDialogue.name);
        Debug.Log(thisNPC.name);**/

        if (sentences.Count == 1)
        {
            acceptQuest.SetActive(true);
            continueDialogue.SetActive(false);
            continueDialogue2.SetActive(false);
            continueDialogue3.SetActive(false);
        }

        if (thisDialogue.name == "Cientifico de Guardia" && thisNPC.name == "guardscientist")
        {
            Debug.Log("estamos del 14 al 11");

            if (sentences.Count == 14 || sentences.Count == 13 || sentences.Count == 12)
            {
                camGuard2.SetActive(true);
            }
            if (sentences.Count == 11 || sentences.Count == 10)
            {
                Debug.Log("estamos en el 10 o el 9");
                camGuard2.SetActive(false);
                camGuard3.SetActive(true);
            }
            if (sentences.Count == 9 || sentences.Count == 8 || sentences.Count == 7)
            {
                camGuard3.SetActive(false);
                camGuard5.SetActive(true);
            }
            if (sentences.Count <= 6)
            {
                camGuard5.SetActive(false);
                camGuard2.SetActive(true);
            }
        }

        if (GameManager.manager.GetToTextQuest() == "Sin luz y sin defensas" && thisNPC.name == "guardscientist")
        {
            if (sentences.Count == 12)
                camGuard2.SetActive(true);

            if (sentences.Count == 11)
            {
                camGuard2.SetActive(false);
                camGuard3.SetActive(true);
            }
            if (sentences.Count == 10)
            {
                camGuard2.SetActive(false);
                camMain1.SetActive(true);
                nameText.text = "Cientifico Principal";
            }
            if (sentences.Count <= 10)
            {
                GameObject.FindGameObjectWithTag("mainscientist").transform.localPosition = new Vector3(-45.27f, 0.1f, -8.6f);
                GameObject.FindGameObjectWithTag("mainscientist").GetComponent<Animator>().Play("Idle");
            }
            if (sentences.Count == 9 || sentences.Count == 8 || sentences.Count == 7 || sentences.Count == 6 || sentences.Count == 5)
            {
                nameText.text = thisDialogue.name;

                camMain1.SetActive(false);
                camGuard1.SetActive(true);
            }
            if (sentences.Count == 4)
            {
                camGuard1.SetActive(false);
                camGuard2.SetActive(true);
            }
            if (sentences.Count == 3 || sentences.Count == 2 || sentences.Count == 1)
            {
                camGuard2.SetActive(false);
                camGuard5.SetActive(true);
            }
            if (sentences.Count == 0)
            {
                camGuard5.SetActive(false);
                camGuard4.SetActive(true);
                thisNPCcam = camGuard4.GetComponent<Camera>();
            }
        }

        if (thisDialogue.name == "Director" && thisNPC.name == "Director")
        {

            if (sentences.Count == 5)
            {
                camDir2.SetActive(false);
                camDir3.SetActive(true);
            }
            if (sentences.Count == 4)
            {
                camDir3.SetActive(false);
                camDir2.SetActive(true);
            }
            if (sentences.Count == 3)
            {
                camDir2.SetActive(false);
                camDir1.SetActive(true);
            }

            if (sentences.Count == 2)
            {
                camDir1.SetActive(false);
                camDir3.SetActive(true);
            }
            if (sentences.Count == 1 || sentences.Count == 0)
            {
                camDir3.SetActive(false);
                camDir2.SetActive(true);
            }
        }

        //FindObjectOfType<DialogueTrigger>().anim.Play("Talk");
        string sentence = sentences.Dequeue();
        description.text = sentence;
        //if we activate the quest, we finish the dialogue
        acceptQuest.GetComponent<Button>().onClick.AddListener(() => EndDialogue());
    }

    public void EndDialogue()
    {
        if(anim != null)
            anim.Play("Idle");

        if (GameManager.manager.GetToTextQuest() == "Héroe sin capa" && gameObject.name == "Director")
        {
            Debug.Log("enddialogue con director");
            dialogueOrNote.gameObject.SetActive(false);
            GameManager.manager.endSuccessGame();
            dialogueOrNote.gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<DialogueTrigger>().player.SetActive(true);
            dialogueOrNote.gameObject.SetActive(false);
            FindObjectOfType<MainController>().enabled = true;
            FindObjectOfType<CameraFollow>().enabled = true;

            thisNPCcam.enabled = false;
            if (GameObject.FindGameObjectWithTag("NPCcams") != null)
                GameObject.FindGameObjectWithTag("NPCcams").SetActive(false);
        }
        FindObjectOfType<QuestGiver>().AcceptQuest(thisNPC);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameManager.manager.interfaceDisplay.SetActive(true);

    }
}
