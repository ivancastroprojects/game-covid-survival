using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CambioDeEscenaBaja2Baja1 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("PLANTA BAJA 1 ESCENA FINAL");
            GetComponent<InstantiateScene>().respawn.name = "Location Baja1Baja2";
        }
    }
}