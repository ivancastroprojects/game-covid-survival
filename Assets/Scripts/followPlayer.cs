using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private syringe playerFollowed;
    private void Start()
    {
       // playerFollowed = GameObject.FindGameObjectWithTag("Syringe").GetComponent<syringe>();
    }
    void LateUpdate()
    {
        if (Input.GetButton("Fire1") && GameManager.manager.munitionDose > 0) offset.Set(0.01f, 1.5f, -0.1f);
        else offset.Set(0, 1.7f, -5);

        transform.position = player.position + offset;

       
    }
}
