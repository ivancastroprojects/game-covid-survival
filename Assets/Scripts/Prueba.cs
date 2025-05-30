using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prueba : MonoBehaviour
{
    public static Prueba instance;
    private void Awake()
    {
        if (instance == null && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MENU"))
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
