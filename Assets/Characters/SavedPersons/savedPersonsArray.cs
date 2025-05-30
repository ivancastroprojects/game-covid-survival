using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class savedPersonsArray : MonoBehaviour
{

    public GameObject[] savedPersons;

    public void choosePerson(GameObject converted)
    {
        int randomPerson = Random.Range(1, 13);

        if (converted.name == "BOSSfifthpatient")
        {
            GameObject selected = Instantiate(savedPersons[0], converted.transform.position, Quaternion.identity);
            StartCoroutine(TimeAlive(selected));
        }
        else
        {
            GameObject selected = Instantiate(savedPersons[randomPerson], converted.transform.position, Quaternion.identity);
            StartCoroutine(TimeAlive(selected));
        }
    }

    IEnumerator TimeAlive(GameObject selected)
    {
        yield return new WaitForSeconds(5);
        Destroy(selected);
    }
}