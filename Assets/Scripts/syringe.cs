using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class syringe : MonoBehaviour
{
    public float dose = 10f;
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
    //Transform actualTransform;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainController>();
        cameras = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<changingCameras>();
        muzzleFlash = GameObject.FindGameObjectWithTag("MuzzleFlashOP").GetComponent<ParticleSystem>();
        //fpsCam = GameObject.FindGameObjectWithTag("GunCamera").GetComponent<Camera>();
        //actualTransform = gameObject.transform;

        if (ammoDisplay == null)
        {
            ammoDisplay = GameManager.manager.interfaceDisplay.transform.GetChild(0).gameObject.GetComponent<Text>();
            ammoDisplay.text = GameManager.manager.munitionDose.ToString();
        }

        if (GameManager.manager != null)
        {
            if (GameManager.manager.quest.activateSyringe)
                canShoot = true;
            else canShoot = false;
        }
        else canShoot = true;
    }

    void Update()
    {
        //if (fpsCam == null)
        //fpsCam = GameObject.Find("/CameraBase/GunCamera").GetComponent<Camera>();

        if (cameras == null)
            cameras = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<changingCameras>();

        if (ammoDisplay == null)
        {
            ammoDisplay = GameManager.manager.interfaceDisplay.transform.GetChild(0).gameObject.GetComponent<Text>();
            ammoDisplay.text = GameManager.manager.munitionDose.ToString();
        }

        if (GameManager.manager != null)
        {
            if (GameManager.manager.munitionDose <= 0)
            {
                canShoot = false;
                player.gameObject.GetComponent<Health_and_Damage>().GameOver();
            }
        }

        if (canShoot)
        {
            //apuntar y disparar
            if (Input.GetButton("Fire1") && Input.GetButton("Fire2") && Time.time >= nextTimeToFire && GameManager.manager.munitionDose > 0)
            {
                //posicion jeringuilla en disparo
                //gameObject.transform.position = new Vector3(0.17f, -0.037f, -0.001f);
                //gameObject.transform.Rotate(48.991f, -183.5f, -349.5f, Space.Self);

                player.anim.Play("Gunplay");
                cameras.Point();
                Shooting();
            }
            //disparar
            else if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire /**&& GameManager.manager.munitionDose > 0**/)
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

        if (GameManager.manager != null)
        {
            GameManager.manager.munitionDose--;
            ammoDisplay.text = GameManager.manager.munitionDose.ToString();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        //gameObject.GetComponent<AudioSource>().clip = shootingWater;
        gameObject.GetComponent<AudioSource>().volume = 1f;
        GetComponent<AudioSource>().Play();

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

    /**
    public float dose = 10f;
   // public float munitionDose
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    public Text ammoDisplay;
    private health_and_damageIA target;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    private MainController player;
    private changingCameras cameras;
    private float nextTimeToFire = 0f;
    public bool canShoot; //{ get; set; }
    public static syringe instance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MainController>();
        cameras = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<changingCameras>();
        muzzleFlash = GameObject.FindGameObjectWithTag("MuzzleFlashOP").GetComponent<ParticleSystem>();
       // fpsCam = GameObject.FindGameObjectWithTag("GunCamera").GetComponent<Camera>();
        
        ammoDisplay = GameManager.manager.interfaceDisplay.transform.GetChild(0).gameObject.GetComponent<Text>();
            
        ammoDisplay.text = GameManager.manager.munitionDose.ToString();   
        canShoot = false;
    }
    void Update()
    {
        if(fpsCam == null)
            //fpsCam = GameObject.Find("/CameraBase/GunCamera").GetComponent<Camera>();

        if(ammoDisplay==null)
            ammoDisplay = GameManager.manager.interfaceDisplay.transform.GetChild(0).gameObject.GetComponent<Text>();

        ammoDisplay.text = GameManager.manager.munitionDose.ToString();
        //Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        //Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 400, Color.yellow);

        //apuntar y disparar
        if (canShoot)
          {
            //Shoot();
            if (Input.GetButton("Fire1") && Input.GetButton("Fire2") && Time.time >= nextTimeToFire && GameManager.manager.munitionDose > 0)
            {
                player.anim.Play("Gunplay");
                cameras.Point();
                Shooting();
            }
            //disparar
            else if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && GameManager.manager.munitionDose > 0)
            {
                player.anim.Play("Gunplay");
                cameras.ThirdPersonPoint();
                Shooting();
            }
            //apuntar
            else if (Input.GetButton("Fire2"))
            {
                player.anim.Play("Point");
                cameras.Point();
            }
            else cameras.Dispoint();
          }
        //PJ se mueve en dirección hacia donde apuntamos
        //if (Input.GetButton("Fire1") || Input.GetButton("Fire2"))
        //player.GetComponent<MainController>().transform.rotation = Quaternion.LookRotation(Input.mousePosition);
    }

    void Shooting() //Disparando
    {
        nextTimeToFire = Time.time + 1f / fireRate;

        Shoot();
        GameManager.manager.munitionDose--;
        ammoDisplay.text = GameManager.manager.munitionDose.ToString();
    }

    void Shoot()
    {
        //muzzleFlash.Play();

        RaycastHit hit;
        //Ray rayOrigin = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f,0f));
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayOrigin.origin, rayOrigin.direction * 400, Color.yellow);
        //player.transform.rotation = Quaternion.LookRotation(Input.mousePosition);
        if (Physics.Raycast(rayOrigin,out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Debug.Log(hit.transform.gameObject.name);
            Debug.Log(transform.parent.gameObject.name);
           //player.transform.LookAt(hit.point);
            target = hit.transform.GetComponent<health_and_damageIA>();



            // if (hit.rigidbody != null)
            //{
            //  hit.rigidbody.AddForce(-hit.normal * impactForce);
            //}
            Vector3 direction = hit.point - player.transform.position;
            direction.y = 0f;
            Debug.Log(direction);
            direction.Normalize();
            player.transform.forward = direction;
            Debug.Log(player.transform.forward);
            if (target != null)
               {
                    //Vector3 direction = hit.point - rayOrigin.origin;
                
                //Quaternion newDirection = Quaternion.LookRotation(direction);
                //  player.transform.rotation = newDirection;
               
                   // target.TakeDose(dose);
                  //  GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    //Destroy(impactGO, 2f);
                }
        }
    }**/
}
