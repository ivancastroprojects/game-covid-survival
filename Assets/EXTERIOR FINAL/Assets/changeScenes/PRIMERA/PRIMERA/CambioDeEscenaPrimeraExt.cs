using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPrimeraExt : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("PlantaPrimeraEntrada");
            GetComponent<InstantiateScene>().respawn.name = "Location PrimeraExt";
        }
    }
}
