using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Camera Settings")]
    public float mouseSensativity = 2f;
    public float verticalClamp = 90f;
    public GameObject cameraHolder;

    [Header("Movement Settings")]
    public float speed;

    float xRot, yRot;

    //public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleCamera();
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


            transform.Translate(moveDir * speed * Time.deltaTime); 

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
}
