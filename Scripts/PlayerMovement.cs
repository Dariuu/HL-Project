using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public Transform headCheck;

    public float groundDistance = 0.4f;
    public float headDistance = .5f;

    public LayerMask groundMask;
    public LayerMask headMask;

    public float speed = 10f;
    public float crouchSpeed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private float movingSpeed;

    Vector3 velocity;
    bool isGrounded;

    bool isCrouching;
    bool headSpace;

    public Transform cam;
    public Vector3 camCrouched;
    public Vector3 camInitial;

    Animator animator;
    public GameObject WeaponHolder;
    // Start is called before the first frame update
    void Start()
    {
        cam.localPosition = camInitial;

        animator = WeaponHolder.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        headSpace = Physics.CheckSphere(headCheck.position, headDistance, headMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * movingSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            animator.SetBool("run", true);
        }else{
            animator.SetBool("run", false);
        }

        //Crouch
        if (isCrouching && headSpace)
        {   
            cam.localPosition = Vector3.Lerp(cam.localPosition, camCrouched, 1f);
            controller.height = 1f;
        }else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, camCrouched, 1f);
            controller.height = 1f;
            isCrouching = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl) && !headSpace)
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, camInitial, 1f);
            controller.height = 2f;
            isCrouching = false;
        }
        else
        {
            cam.localPosition = Vector3.Lerp(cam.localPosition, camInitial, 1f);
            controller.height = 2f;
            isCrouching = false;
        }

        if (isCrouching)
        {
            movingSpeed = crouchSpeed;
        }
        else
        {
            movingSpeed = speed;
        }
    }
}
