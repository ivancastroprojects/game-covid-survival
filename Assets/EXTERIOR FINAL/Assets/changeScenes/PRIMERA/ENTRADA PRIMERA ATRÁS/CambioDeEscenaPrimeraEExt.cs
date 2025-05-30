using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaPrimeraEExt : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("EXTERIORCASIFINAL");
            GetComponent<InstantiateScene>().respawn.name = "Location ExtPrimeraE";
        }
    }
}
