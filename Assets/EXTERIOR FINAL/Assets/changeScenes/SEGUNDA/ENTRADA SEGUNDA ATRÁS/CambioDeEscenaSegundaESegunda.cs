using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaSegundaESegunda : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("SegundaPlanta");
            GetComponent<InstantiateScene>().respawn.name = "Location SegundaSegundaE";
        }
    }
}
