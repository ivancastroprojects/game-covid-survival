using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPrimeraSegundaED : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SegundaPlanta");
            GetComponent<InstantiateScene>().respawn.name = "Location PrimeraSegundaED";
        }
    }
}
