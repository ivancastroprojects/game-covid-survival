using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CambioDeEscenaExtPrimeraE : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("PlantaPrimeraEntrada");
            GetComponent<InstantiateScene>().respawn.name = "Location PrimeraEExt";
        }
    }
}