using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaBaja1Baja2 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("PLANTA BAJA 2 ESCENA FINAL");
            GetComponent<InstantiateScene>().respawn.name = "Location Baja2Baja1";
        }
    }
}
