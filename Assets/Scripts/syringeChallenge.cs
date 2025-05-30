using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class syringeChallenge : MonoBehaviour
{
    public float dose = 10f;
   // public float munitionDose
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public Text ammoDisplay;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private MainController player;
    private changingCameras cameras;
    private float nextTimeToFire = 0f;
    public bool canShoot;
    public static syringe instance;
    public AudioSource audioSource;
    float munitionDose = 10000000000;
    Transform actualTransform;

    public AudioClip shootingWater;
    public AudioClip incrementSound;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainController>();
        cameras = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<changingCameras>();
        //fpsCam = GameObject.FindGameObjectWithTag("GunCamera").GetComponent<Camera>();
        actualTransform = gameObject.transform;

        canShoot = true;
    }

    void Update()
    {
        //if (fpsCam == null)
            //fpsCam = GameObject.Find("/CameraBase/GunCamera").GetComponent<Camera>();

        if (canShoot)
        {
            if(player == null)
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainController>();

            //apuntar y disparar
            if (Input.GetButton("Fire1") && Input.GetButton("Fire2") && Time.time >= nextTimeToFire && munitionDose > 0)
            {
                //posicion jeringuilla en disparo
                //gameObject.transform.position = new Vector3(0.17f, -0.037f, -0.001f);
                //gameObject.transform.Rotate(48.991f, -183.5f, -349.5f, Space.Self);

                player.anim.Play("Gunplay");
                cameras.Point();
                Shooting();
            }
            //disparar
            else if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && munitionDose > 0)
            {
                //posicion jeringuilla en disparo
                //gameObject.transform.position = new Vector3(0.17f, -0.037f, -0.001f);
                //gameObject.transform.Rotate(48.991f, -183.5f, -349.5f, Space.Self);

                player.anim.Play("Gunplay");
                cameras.ThirdPersonPoint();
                Shooting();
            }
            //apuntar
            else if (Input.GetButton("Fire2"))
            {
                //posicion jeringuilla en disparo
                //gameObject.transform.position = new Vector3(0.17f, -0.037f, -0.001f);
                //gameObject.transform.Rotate(48.991f, -183.5f, -349.5f, Space.Self);

                player.anim.Play("Point");
                cameras.Point();
            }
            else
            {
                //volver jeringuilla a su transform
                //gameObject.transform.position = actualTransform.transform.position;
                //gameObject.transform.rotation = actualTransform.transform.rotation;
                cameras.Dispoint();
            }
        }

    }

    void Shooting() //Disparando
    {
        nextTimeToFire = Time.time + 1f / fireRate;
        Shoot();
    }

    void Shoot()
    {
        muzzleFlash.Play();
        gameObject.GetComponent<AudioSource>().clip = shootingWater;
        gameObject.GetComponent<AudioSource>().volume = 1f;
        gameObject.GetComponent<AudioSource>().Play();

        RaycastHit hit;
        if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            health_and_damageIA target = hit.transform.GetComponent<health_and_damageIA>();
            if (target != null)
            {
                target.TakeDose(dose);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //PJ se mueve en dirección hacia donde apuntamos
            //if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
            //player.GetComponent<MainController>().transform.rotation = Quaternion.LookRotation(hit.point);

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    public void incrementDose(GameObject incrementSyringe)
    {
        gameObject.GetComponent<AudioSource>().clip = incrementSound;
        gameObject.GetComponent<AudioSource>().volume = 0.5f;
        gameObject.GetComponent<AudioSource>().Play();

        if (SceneManager.GetActiveScene().name == "CHALLENGE MODE 3")
        {
            dose = 100f;
            Debug.Log(dose);
        }
        else dose = 50f;

        GameObject.FindGameObjectWithTag("iconIncrement").GetComponent<Image>().enabled = true;
        Destroy(incrementSyringe);

        StartCoroutine(CuroMasUnosSegundos());
    }

    //Durante 15 segundos curamos 5 veces más
    IEnumerator CuroMasUnosSegundos()
    {
        yield return new WaitForSeconds(15);
        dose = 10f;
        GameObject.FindGameObjectWithTag("iconIncrement").GetComponent<Image>().enabled = false;
    }
}
