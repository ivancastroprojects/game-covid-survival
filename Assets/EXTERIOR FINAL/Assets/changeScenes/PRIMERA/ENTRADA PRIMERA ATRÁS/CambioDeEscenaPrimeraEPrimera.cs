using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPrimeraEPrimera : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("planta primera");
            GetComponent<InstantiateScene>().respawn.name = "Location PrimeraPrimeraE";
        }
    }
}
