using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TransicionMenu : MonoBehaviour
{
    public GameObject panelmenu, panelhistoria, paneldesafio, panelayuda, panelcreditos;
    public GameObject panelhistoriaPartida, paneldesafioPartida;
    public GameObject panelhistoriaUnCaracter, panelhistoriaMultiCaracter, 
                      paneldesafioUnCaracter, paneldesafioMultiCaracter;
    public float timeMenu = 6f;

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public void Awake()
    {
        Invoke("appearMenu", timeMenu);
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.Escape) && GameObject.FindGameObjectWithTag("video"))
            GameObject.FindGameObjectWithTag("video").SetActive(false);
    }

    /** Ventanas iniciales **/

    //MENU PRINCIPAL
    public void appearMenu()
    {

        if(panelmenu != null)
            panelmenu.SetActive(true);
    }
    
    //ESCOGER MODO
    public void modoHistoria()
    {
        panelmenu.SetActive(false);
        panelhistoria.SetActive(true);
    }

    public void modoDesafio()
    {
        panelmenu.SetActive(false);
        paneldesafio.SetActive(true);
    }

    public void modoAyuda()
    {
        panelmenu.SetActive(false);
        panelayuda.SetActive(true);
    }

    public void modoCreditos()
    {
        panelmenu.SetActive(false);
        panelcreditos.SetActive(true);
    }

    //back MODO SELECCIONADO --> MENU PRINCIPAL
    public void backMenuPrincipal()
    {
        panelhistoria.SetActive(false);
        paneldesafio.SetActive(false);
        panelayuda.SetActive(false);
        panelcreditos.SetActive(false);

        panelmenu.SetActive(true);
    }

    /** Ventanas UN JUGADOR y MULTIJUGADOR **/

    /*****************   MODO HISTORIA   ********************/

    //UN JUGADOR --> CARACTER
    public void modoHistoriaUnJugador()
    {
        panelhistoria.SetActive(false);
        panelhistoriaUnCaracter.SetActive(true);
    }

    //MULTIJUGADOR --> PARTIDA
    public void modoHistoriaMulti()
    {
        panelhistoria.SetActive(false);
        panelhistoriaPartida.SetActive(true);
    }

    //PARTIDA --> CHARACTER (Multijugador)
    public void modoHistoriaCaracter()
    {
        panelhistoriaPartida.SetActive(false);
        panelhistoriaMultiCaracter.SetActive(true);
    }

    //BACK MODO HISTORIA
    public void backModoHistoria()
    {
        panelhistoriaUnCaracter.SetActive(false);
        panelhistoriaMultiCaracter.SetActive(false);
        panelhistoriaPartida.SetActive(false);
        panelhistoria.SetActive(true);
    }


    /*****************   MODO DESAFIO   ********************/

    //UN JUGADOR --> CARACTER
    public void modoDesafioUnJugador()
    {
        paneldesafio.SetActive(false);
        paneldesafioUnCaracter.SetActive(true);
    }

    //MULTIJUGADOR --> PARTIDA
    public void modoDesafioMulti()
    {
        paneldesafio.SetActive(false);
        paneldesafioPartida.SetActive(true);
    }

    //PARTIDA --> CHARACTER (Multijugador)
    public void modoDesafioCaracter()
    {
        paneldesafioPartida.SetActive(false);
        paneldesafioMultiCaracter.SetActive(true);
    }

    //BACK MODO HISTORIA
    public void backModoDesafio()
    {
        paneldesafioUnCaracter.SetActive(false);
        paneldesafioMultiCaracter.SetActive(false);
        paneldesafioPartida.SetActive(false);
        paneldesafio.SetActive(true);
    }


    /*****************   OTRAS VENTANAS   ********************/

    //CARGAR ESCENA DEL MODO
    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);

        panelhistoriaUnCaracter.SetActive(false);
        paneldesafioUnCaracter.SetActive(false);
        panelhistoriaMultiCaracter.SetActive(false);
        paneldesafioMultiCaracter.SetActive(false);

        if(loadingScreen.activeInHierarchy)
            StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    //SALIR
    public void salir()
    {
        Application.Quit();
    }

    //LOADING
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
           // Debug.Log(progress);
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
