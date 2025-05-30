using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncrementDamage : MonoBehaviour
{
    float x, y, z;
    Vector3 pos;
    public GameObject syringePlayer;

    void Start()
    {
        x = Random.Range(-100, 140);
        y = 0.8f;
        z = Random.Range(-100, 140);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Syringe").GetComponent<syringeChallenge>().incrementDose(gameObject);
        }
    }
}
