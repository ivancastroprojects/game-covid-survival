using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollTerrorEnElMIC : MonoBehaviour
{
    public Transform teleport;
    public WhenComplete complete;
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log(player.transform.position);
            MainController.instance.transform.position = teleport.position;
            MainController.instance.transform.rotation = teleport.rotation;
            complete.GoQuest();
            //Debug.Log(MainController.instance.transform.position);

        }
    }
    
}
