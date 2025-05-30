using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPrimeraESegundaE : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SegundaPlantaEntrada");
            GetComponent<InstantiateScene>().respawn.name = "Location SegundaEPrimeraE";
        }
    }
}
