using System.Collections;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Camera Settings")]
    public float mouseSensativity = 2f;
    public float verticalClamp = 90f;
    public GameObject cameraHolder;
    public GameObject clubPos;

    [Header("Movement Settings")]
    public float speed;
    
    public float jumpForce;

    float xRot, yRot;

    public bool isMovingUp;
    public Rigidbody rb;
    [SerializeField] float maxVelocity;
    double jumpTimer;

    [SerializeField] float velocity;
    [SerializeField] float linearDampening;

    //public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        velocity = rb.linearVelocity.magnitude;
        HandleMovement();
        HandleCamera();
        HandleJump();

        if (velocity <= .1f)
        {
            rb.linearVelocity = Vector3.zero;
        }
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
    }

    void HandleMovement()
    {
        float movez = Input.GetAxis("Horizontal");
        float movex = Input.GetAxis("Vertical");
        

        Vector3 moveDir = new Vector3( movez, 0, movex);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5;
        }
        else
        {
            speed = 2;
        }
        //transform.Translate(moveDir * speed * Time.deltaTime); 
        rb.AddForce(transform.TransformDirection(moveDir) * speed, ForceMode.Acceleration);

        // if (movez <= .01f && movex <= .01f)
        // {
        //     rb.linearVelocity = Vector3.zero;
        // }

        //animator.SetFloat("vertical", movex);
        //animator.SetFloat("horizontal", movez);
    }

    void HandleCamera()
    {
        float mousex = Input.GetAxis("Mouse Y");
        float mousey = Input.GetAxis("Mouse X");

        xRot -= mousex * mouseSensativity;
        xRot = Mathf.Clamp(xRot, -verticalClamp, verticalClamp);
        yRot += mousey * mouseSensativity;

        cameraHolder.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMovingUp)
        {
            isMovingUp = true;
            jumpTimer = Time.time + .1f;
            StartCoroutine(JumpSmoother());
            rb.linearDamping = 1;
        }
    }

    IEnumerator JumpSmoother()
    {
        while (Input.GetKey(KeyCode.Space) && isMovingUp && Time.time < jumpTimer)
        {
            //transform.Translate(Vector3.up * .1f); for just moving the player up without physics
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);// physics based jump

            yield return new WaitForSeconds(.1f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isMovingUp)
        {
            //isMovingUp = false;
            //rb.linearVelocity = Vector3.zero;
            rb.linearDamping = 3;
            isMovingUp = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isMovingUp = true;
    }
}
