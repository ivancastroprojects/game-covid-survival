using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TextCompletedQuest : MonoBehaviour
{
    public void Start()
    {
        GameObject texto = gameObject;
        texto.GetComponent<Text>().enabled = false;
    }

}
