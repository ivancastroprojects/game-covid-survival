using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class Health_and_DamageChallenge : MonoBehaviour
{
    //Life of character
    public float converted = 0;
    //Variable to be invulnerable a short period of time after the enemies hit you
    public bool invencible = false;
    public float tiempo_invencible = 1f;
    //Variable to walk more slow a short period of time when the enemies hit you
    public float tiempo_frenado = 0.2f;

    public GameObject mutant;
    public Image barraDeVida;
    public Image imageDamage;
    public GameObject chronometer;
    public GameObject endGameText;
    public Color temp;

    private Animator anim;
    public static Health_and_Damage instance;

    private void Start()
    {
        anim = GetComponent<Animator>();

        mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");
        barraDeVida = GameObject.Find("/Canvas/LifeAndMunition/BarraDeVida").GetComponent<Image>();
        imageDamage = GameObject.Find("/Canvas/ImageDamage").GetComponent<Image>();
        chronometer = GameObject.Find("/Canvas/Chronometer");
        endGameText = GameObject.Find("/Canvas/endGameText");
        
        barraDeVida.fillAmount = 0;
        temp = imageDamage.color;
        temp.a = 0f;
        imageDamage.color = temp;
        endGameText.SetActive(false);
    }

    //Fuction that controls the amount of life that enemies take from the character
    public void RestarVida(float damage)
    {
        if (mutant == null)
            mutant = GameObject.Find("/Enemies/ADDSmutantpersons (1)");

        if (barraDeVida == null)
            GameObject.Find("/Canvas/LifeAndMunition/BarraDeVida").GetComponent<Image>();

        if (imageDamage == null)
            imageDamage = GameObject.Find("/Canvas/ImageDamage").GetComponent<Image>();

        converted = Mathf.Clamp(converted, 0, 100);

        if (!invencible && converted < 100 /**&& Cursor.lockState != CursorLockMode.None**/)
        {
            converted += damage;
            anim.Play("Damage");

            if (barraDeVida.fillAmount >= 0.4f && barraDeVida.fillAmount <= 0.6f)
            {
                temp.a += 0.2f;
                imageDamage.color = temp;
            }
            if (barraDeVida.fillAmount >= 0.6f && barraDeVida.fillAmount <= 0.8f)
            {
                temp.a += 0.2f;
                imageDamage.color = temp;
            }
            if (barraDeVida.fillAmount >= 0.8f && barraDeVida.fillAmount <= 1f)
            {
                temp.a += 0.1f;
                imageDamage.color = temp;
            }

            if (temp.a >= 1f)
            {
                temp.a = 1f;
                imageDamage.color = temp;
            }

            barraDeVida.fillAmount = converted / 100;
            Debug.Log("barra" + barraDeVida.fillAmount);
            Debug.Log("converted" + converted);
            StartCoroutine(Invulnerabilidad());
            StartCoroutine(FrenarVelocidad());
            if (barraDeVida.fillAmount >= 1) GameOver();
        }
    }

    //Function that controls the amount of life that vacune cure us
    public void SumarVida(float dose)
    {
        converted -= dose;
        temp.a -= 0.4f;
        imageDamage.color = temp;

        barraDeVida.fillAmount = converted / 100;

        if (barraDeVida.fillAmount <= 0)
            barraDeVida.fillAmount = 0;
    }
  
    //End of game
    void GameOver()
    {
        //Has sido convertido. GAME OVER.

        GameObject questWindow = GameObject.Find("/Canvas/RememberQuest");
        questWindow.SetActive(false);

        Debug.Log("Has sido convertido. GAME OVER.");
        Instantiate(mutant, gameObject.transform.position, Quaternion.identity);
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        temp = imageDamage.color;
        temp.a = 0f;
        imageDamage.color = temp;

        if (chronometer != null)
            chronometer.SetActive(false);

        endGameText.SetActive(true);
        endGameText.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => converted = 0);

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
