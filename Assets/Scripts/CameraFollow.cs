using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
   // public GameObject CameraObj;
    //public GameObject PlayerObj;
    //public float camDistanceXToPlayer;
    //public float camDistanceYToPlayer;
    //public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    //public float finalInputX;
    //public float finalInputZ;
    //public float smoothX;
    //public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;
    public bool moveCam;
    private Transform target;
  
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
      
        moveCam = true;

        CameraFollowObj = GameObject.FindGameObjectWithTag("cameraFollow");
    }
 
    public void canMoveCam(bool moveCam)
    {
        this.moveCam = moveCam;
    }
    void Update()
    {
        if (moveCam)
        {
            //Here setup the rotation
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");

            rotY += mouseX * inputSensitivity * Time.deltaTime;
            rotX += mouseY * inputSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            transform.rotation = localRotation;
           
        }
        else
        {
            rotX = 0.0f;
            rotY = 0.0f;
        }

        if(CameraFollowObj == null)
            CameraFollowObj = GameObject.FindGameObjectWithTag("cameraFollow");
    }
    private void LateUpdate()
    {
        CameraUpdater();
    }
    public void CameraUpdater()
    {
        if (CameraFollowObj != null)
        {
            target = CameraFollowObj.transform;

            float step = CameraMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    public void LookMouse()
    {
        
    }
}
