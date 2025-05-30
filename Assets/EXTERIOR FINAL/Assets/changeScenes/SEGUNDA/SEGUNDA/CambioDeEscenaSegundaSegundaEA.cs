using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaSegundaSegundaEA : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SegundaPlantaEntrada");
            GetComponent<InstantiateScene>().respawn.name = "Location SegundaEASegunda";
        }
    }
}
