using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CambioDeEscena2 : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
{
            SceneManager.LoadScene("SegundaPLantaEntrada");
        }
    }
}