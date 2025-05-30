using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
public class Health_and_Damage : MonoBehaviour
{
    //Life of character
    public static float converted = 0;
    //Variable to be invulnerable a short period of time after the enemies hit you
    public bool invencible = false;
    public float tiempo_invencible = 1f;
    //Variable to walk more slow a short period of time when the enemies hit you
    public float tiempo_frenado = 0.2f;
    public GameObject mutant;
    public Image barraDeVida;
    public Image imageDamage;
    public GameObject chronometer;
    //Para el modo desafio que no lleva GameManager
    public GameObject endGameText;
   
    private Animator anim;
    public static Health_and_Damage instance;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");
        endGameText = GameManager.manager.endGameText;

        if (barraDeVida == null)
            barraDeVida = GameManager.manager.barraVida;

        if (imageDamage == null)
            imageDamage = GameManager.manager.imageDamage;

        if (endGameText == null)
            endGameText = GameManager.manager.endGameText;

        GameManager.manager.temp = GameManager.manager.imageDamage.color;
        GameManager.manager.temp.a = 0f;
        imageDamage.color = GameManager.manager.temp;
    }

    //Fuction that controls the amount of life that enemies take from the character
    public void RestarVida(float damage)
    {
        if (mutant == null)
            mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");

        if (imageDamage == null)
            imageDamage = GameManager.manager.imageDamage;

        if (endGameText == null)
            endGameText = GameManager.manager.endGameText;

        converted = Mathf.Clamp(converted, 0, 150);
        barraDeVida = GameManager.manager.barraVida;

        if (!invencible && converted < 100 && barraDeVida.fillAmount < 1)
        {
            converted += damage;
            anim.Play("Damage");

            if (GameManager.manager.barraVida.fillAmount >= 0.4f && GameManager.manager.barraVida.fillAmount <= 0.6f)
            {
                GameManager.manager.temp.a += 0.1f;
                imageDamage.color = GameManager.manager.temp;
            }
            if (GameManager.manager.barraVida.fillAmount >= 0.6f && GameManager.manager.barraVida.fillAmount <= 0.8f)
            {
                GameManager.manager.temp.a += 0.1f;
                imageDamage.color = GameManager.manager.temp;
            }
            if (GameManager.manager.barraVida.fillAmount >= 0.8f && GameManager.manager.barraVida.fillAmount <= 1f)
            {
                GameManager.manager.temp.a += 0.1f;
                imageDamage.color = GameManager.manager.temp;
            }

            if (GameManager.manager.temp.a >= 1f)
            {
                GameManager.manager.temp.a = 1f;
                imageDamage.color = GameManager.manager.temp;
            }

            GameManager.manager.barraVida.fillAmount = converted / 100;

            /**Debug.Log("barradevida: " + barraDeVida.fillAmount);
            Debug.Log("barra manager: " + GameManager.manager.barraVida.fillAmount);**/

            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            if (GameManager.manager.barraVida.fillAmount >= 1) GameOver();
        }
    }

    //Function that controls the amount of life that vacune cure us
    public void SumarVida(float dose)
    {
        converted -= dose;
        GameManager.manager.temp.a -= 0.4f;
        imageDamage.color = GameManager.manager.temp;

        barraDeVida.fillAmount = converted / 100;

        if (barraDeVida.fillAmount <= 0)
            barraDeVida.fillAmount = 0;
    }
  
    //End of game
    public void GameOver()
    {
        //Has sido convertido. GAME OVER.

        GameObject questWindow = GameObject.Find("/Canvas/RememberQuest");
        if (questWindow != null)
            questWindow.SetActive(false);

        Debug.Log("Has sido convertido. GAME OVER.");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (GameManager.manager.munitionDose <= 0)
            endGameText.GetComponent<Text>().text = "SE ACABÓ LA MUNICIÓN";
        else Instantiate(mutant, gameObject.transform.position, Quaternion.identity);

        endGameText.SetActive(true);
        endGameText.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => converted = 0);

        gameObject.SetActive(false);

        //if (chronometer != null)
          //  chronometer.SetActive(false);

        Time.timeScale = 0;
    }

    public void GameOverTime()
    {
        GameObject questWindow = GameObject.Find("/Canvas/RememberQuest");
        if (questWindow != null)
            questWindow.SetActive(false);

        Debug.Log("Se acabó el tiempo. GAME OVER.");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameManager.manager.goCheckpoint();

        //if (chronometer != null)
          //  chronometer.SetActive(false);

        Time.timeScale = 0;

    }

    //Time between received damage that main character is inmune 
    IEnumerator Invulnerabilidad()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempo_invencible);
        invencible = false;
    }
    //Braking speed of main character
    IEnumerator FrenarVelocidad()
    {
        var velocidadActual = GetComponent<MainController>().speed;
        GetComponent<MainController>().speed = 0;
        yield return new WaitForSeconds(tiempo_frenado);
        GetComponent<MainController>().speed = velocidadActual;
    }

    
}
