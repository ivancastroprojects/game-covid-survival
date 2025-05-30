using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changingCameras : MonoBehaviour
{
    public  GameObject mira;
    public  Camera fpsCam;
    public  Camera tpsCam;
    
    private void Start()
    {
        tpsCam = GameObject.Find("/CameraBase/MainCamera").GetComponent<Camera>();
        //fpsCam = GameObject.FindGameObjectWithTag("GunCamera").GetComponent<Camera>();
        mira = GameObject.FindGameObjectWithTag("mira");
    }

    public void ThirdPersonPoint() //Apuntando sin mirilla
    {
        mira.GetComponent<Image>().enabled = true;
        //fpsCam.GetComponent<AudioListener>().enabled = false;
    }
    public void Point() //Apuntando con mirilla
    {
        mira.GetComponent<Image>().enabled = true;
        //fpsCam.enabled = true;
        tpsCam.fieldOfView = 20;

        //fpsCam.GetComponent<AudioListener>().enabled = true;
    }
    public void Dispoint() //Desapuntando
    {
        mira.GetComponent<Image>().enabled = false;
        //fpsCam.enabled = false;
        tpsCam.fieldOfView = 60;

       // fpsCam.GetComponent<AudioListener>().enabled = false;
    }

}
