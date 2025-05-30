using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaExtBaja2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("PLANTA BAJA 2 ESCENA FINAL");
            GetComponent<InstantiateScene>().respawn.name = "Location Baja2Ext";
        }
    }
}
