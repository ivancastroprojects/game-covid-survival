using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaBaja1PrimeraE : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("primera planta");
            GetComponent<InstantiateScene>().respawn.name = "Location PrimeraEBaja1";
        }
    }
}
