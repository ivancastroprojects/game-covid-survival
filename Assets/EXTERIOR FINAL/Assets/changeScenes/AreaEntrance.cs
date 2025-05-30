using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
    private void Start()
    {
        if (transitionName == MainController.instance.areaTransitionName)
        {
            MainController.instance.transform.position = transform.position;
            MainController.instance.transform.rotation = transform.rotation;
        }
    }
}