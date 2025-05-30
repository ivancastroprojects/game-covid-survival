using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    Transform lastCheckpoint;

    float secondsCounter = 0;
    float secondsToCount = 10;

    void Update()
    {
        secondsCounter += Time.deltaTime;
        
        if (secondsCounter >= secondsToCount)
        {
            secondsCounter = 0;
            lastCheckpoint = transform;
        }
    }

    public void goCheckpoint(GameObject player, GameObject mutant)
    {
        Color temp;

        //Eliminamos el mutante y activamos el personaje
        if (mutant != null)
        {
            Destroy(mutant);
            gameObject.SetActive(true);
        }
        //Reiniciamos municion
        GameManager.manager.munitionDose = 50;

        //Reiniciamos barra de vida
        GameManager.manager.barraVida.fillAmount = 0;

        //Reiniciamos imagen de daño
        temp = GameManager.manager.imageDamage.color;
        temp.a = 0f;
        GameManager.manager.imageDamage.color = temp;

        //Movemos el personaje al checkpoint
        transform.position = lastCheckpoint.position;

        //Si se acabo el tiempo, reiniciamos cronometro
        GameManager.manager.resetTime();

        Time.timeScale = 1;
    }
}
