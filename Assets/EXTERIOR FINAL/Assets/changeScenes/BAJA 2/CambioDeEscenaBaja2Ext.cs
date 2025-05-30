using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambioDeEscenaBaja2Ext : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponentInChildren<InstantiateScene>().respawn.name = "Location ExtBaja2";
            SceneManager.LoadScene("EXTERIORCASIFINAL");
        }
    }
}