using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassDoors : MonoBehaviour
{
    public Transform teleport;
    AudioSource doorSound;

    public void Start()
    {
        doorSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        MainController.instance.transform.position = teleport.position;
        MainController.instance.transform.rotation = teleport.rotation;
        doorSound.Play();
    }

}
