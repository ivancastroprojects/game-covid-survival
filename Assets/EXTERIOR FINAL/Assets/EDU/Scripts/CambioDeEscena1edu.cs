using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CambioDeEscena1edu : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
{
            SceneManager.LoadScene("PlantaPrimeraEntrada");
        }
    }
}