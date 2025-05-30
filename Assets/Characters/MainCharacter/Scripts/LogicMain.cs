using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using UnityEngine;

public class LogicMain : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.1f;
    private float rotationSpeed = 0.05f;
    private float gravity = 3f;
    public float jumpSpeed = 40f;

    private Transform mainCameraTransform = null;

    private CharacterController controller = null;
    private Animator animator = null;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        Debug.Log(speedSmoothTime);
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 forward = mainCameraTransform.forward;
        Vector3 right = mainCameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;
        Vector3 gravityVector = Vector3.zero;

        /** JUMPING **/
        Debug.Log(controller.isGrounded);
        if(controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
               
                gravityVector.y = jumpSpeed;
                animator.SetBool("Jump", true);
                Debug.Log(gravityVector.y);
                animator.SetFloat("transition", gravityVector.y);
            } 
            else
            {
                animator.SetBool("Jump", false);
                gravityVector.y -= gravity * Time.deltaTime;
                animator.SetFloat("transition", gravityVector.y);
            }
        }
        
        /** MOVEMENT **/
        if(desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
        }

        float targetSpeed = walkSpeed * movementInput.magnitude;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetSpeed = runSpeed * movementInput.magnitude;
        }
        
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);

       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("MovementSpeed", 1f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("MovementSpeed", 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        }

    }
}
