using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IAEnemies : MonoBehaviour
{
    //Variables to gestionate the vision radio and velocity
    public float visionRadius;
    public float speedInitial;
    public float damage = 5;

    //Variable to save the player
    GameObject player;
    //Variable to save the initial position
    Vector3 initialPosition;
    public Animator anim;
    public Vector3 target;
    private NavMeshAgent agent;

    public AudioClip[] audioClips;
    public AudioSource audioMutant;
    public GameObject finish;
    //public AudioListener audioListener;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (GameManager.manager == null && GameObject.FindGameObjectWithTag("conseguido") != null)
        {
            finish = GameObject.FindGameObjectWithTag("conseguido");
        }
            //audioListener = GetComponent<AudioListener>();
            audioMutant = gameObject.GetComponent<AudioSource>();

        speedInitial = agent.speed;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        //Los enemigos vuelvan a su posicion inicial en cualquiera de estas condiciones
        if ((GameManager.manager != null && GameManager.manager.barraVida.fillAmount >= 1) || (GameManager.manager == null && finish.GetComponent<Image>().enabled == true))
        {
            GetComponent<health_and_damageIA>().dosed = false;
            if (agent != null)
            {
                agent.SetDestination(initialPosition);
            }
        }
        else
        {
            //For default our objective will be always our initial position
            target = initialPosition;
            //But if the distance to the player is less than the vision radius, the objective will be the him
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist < visionRadius)
            {
                agent.speed = speedInitial;
                target = player.transform.position;
                agent.SetDestination(target);
                transform.LookAt(target);
                anim.SetBool("detected", true);
            }
            else
            {
                agent.SetDestination(initialPosition);
            }

            //si le damos con una dosis a algun enemigo anim.detected true y nos sigue hasta dist 8
            if (GetComponent<health_and_damageIA>().dosed == true)
            {
                agent.speed = speedInitial;
                target = player.transform.position;
                agent.SetDestination(target);
                transform.LookAt(target);
                anim.SetBool("detected", true);
                if (dist > 13)
                {
                    GetComponent<health_and_damageIA>().dosed = false;
                    agent.SetDestination(initialPosition);
                }
            }

            if (dist < 1.5) 
            {
                anim.Play("Zombie Attack");
                if(GameManager.manager != null)
                    player.GetComponent<Health_and_Damage>().RestarVida(4);
                else player.GetComponent<Health_and_DamageChallenge>().RestarVida(damage);

            }

            if (dist < 3)
            {
                if (GameManager.manager != null)
                    player.GetComponent<Health_and_Damage>().RestarVida(2);
                else player.GetComponent<Health_and_DamageChallenge>().RestarVida(3);

                if (!audioMutant.isPlaying)
                {
                    PlayRandom();
                }
            }

            if (transform.position == agent.destination)
            {
                agent.speed = 0;
                anim.SetBool("detected", false);
            }

            if (GameManager.manager != null) //en el modo desafio está desactivado
            {
                if (GameManager.manager.GetToTextQuest() == "Sin luz y sin defensas" && !GameManager.manager.blockedFourMission)
                {
                    agent.SetDestination(initialPosition);
                    GameManager.manager.blockedFourMission = true;
                }
            }
        }

        //float fixedSpeed = speed * Time.deltaTime;
        Debug.DrawLine(transform.position, target, Color.green);
    }

    void PlayRandom()
    {
        audioMutant.clip = audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        audioMutant.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
