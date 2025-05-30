using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private CharacterController controller;
    //Detecting if we are touching the ground to can jump or not
    public bool isGrounded;
    //Movement
    private float horizontal;
    private float vertical;
    //Velocity
    public float speed;
    //Movement vector
    private Vector3 input;

    public float jumpForce;
    public float fallVelocity;
    public float gravity;
    public float running;

    //Movimiento relativo a la camara
    public Camera main;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;
    public float timer;
    bool isFalling;

    private float auxSpeed;

    //Animations
    public Animator anim;
    public string areaTransitionName;

    public static MainController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        auxSpeed = speed;

        timer = 0f;
        main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (main == null && GameObject.FindWithTag("MainCamera").gameObject.activeInHierarchy)
        {
            main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        isGrounded = controller.isGrounded;
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        input = new Vector3(horizontal, 0, vertical);
        input = Vector3.ClampMagnitude(input, 1);

        //Running - Walking
        if (Input.GetKey(KeyCode.LeftShift)){
            speed = 8;
            anim.SetFloat("Movement", input.magnitude * speed);
        }
        else
        {
            speed = auxSpeed;
            anim.SetFloat("Movement", input.magnitude * speed);
        }

        if(Input.GetKeyDown(KeyCode.S) && (Input.GetButton("Fire1") || Input.GetButton("Fire2")) || (Input.GetButton("Fire1") && Input.GetButton("Fire2")))
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z);
        }

        camDirection();
        movePlayer = input.x * camRight + input.z * camForward;
       
        movePlayer = movePlayer * speed;
        controller.transform.LookAt(controller.transform.position + movePlayer);
        SetGravity();
        PlayerSkills();

        controller.Move(movePlayer * Time.deltaTime);

        if (GameManager.manager != null && Time.timeScale == 1f && !controller.isGrounded && !isFalling)
        {
            isFalling = true;
            Debug.Log("inician 5 seg");
            Debug.Log("Posible caída, contando 5 segundos" + controller.isGrounded);
            StartCoroutine(timeFalling());
        }

        /**isFalling = true;

            do
            {
                timer += Time.deltaTime;
                Debug.Log(timer);

                if (timer == 5f)
                    GameManager.manager.lifeAgain();
            }
            while (!controller.isGrounded);
            isFalling = false;
        }**/

    }
    public void camDirection()
    {
        camForward = main.transform.forward;
        camRight = main.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        //Debug.Log(camForward);
        //Debug.Log(camRight);
        camRight = camRight.normalized;
    }
    public void PlayerSkills()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            anim.SetTrigger("Jump");
        }
    }
    //Controlling the gravity according to the falling after to jump
    public void SetGravity()
    {
        if (controller.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;

        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
            anim.SetFloat("JumpingVelocity", controller.velocity.y);
        }
        anim.SetBool("IsGrounded", controller.isGrounded);
    }

    IEnumerator timeFalling()
    {
        yield return new WaitForSeconds(5f);

        if (!controller.isGrounded)
        {
            Debug.Log("Fin de caida, vamos al checkpoint" + controller.isGrounded);
            isFalling = false;
            GameManager.manager.lifeAgain();
        }
        else isFalling = false;
    }
}
    
