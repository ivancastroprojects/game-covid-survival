using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CambioDeEscena3 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
{
            SceneManager.LoadScene("SegundaPlanta");
        }
    }
}