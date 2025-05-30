using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuneDose : MonoBehaviour
{
    public float dose = 40f;
    float x, y, z;
    Vector3 pos;

    void Start()
    {
        x = Random.Range(-100, 140);
        y = 1f;
        z = Random.Range(-100, 140);
        pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health_and_DamageChallenge>().SumarVida(dose);
            Destroy(gameObject);
        }
    }
}
