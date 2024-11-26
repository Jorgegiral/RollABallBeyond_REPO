using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBA_CONTROLES : MonoBehaviour
{

    [Header("Public References")]
    public Rigidbody playerRb; // Variable para referenciar el Rigibody del jugador, y así modificarlo cuando quiera por código
    public MeshRenderer meshRendererToUse;
    public Material materialAngry;
    public Material materialJoy;
    public Material materialSadness;
    public Material materialFear;
    public Material materialDisgust;


    [Header("Movement Variables")]
    public float speed;
    private float horInput; // Almacén del vector X del input
    private float verInput; // Almacén del vector Y del input (se lo pasaré al Z)
    public bool isInversed;

    [Header("Jump Variables")]
    public float jumpForce;
    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        isInversed = false;
    }

    // Update is called once per frame
    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        Jump();
    }

    private void FixedUpdate()
    {
        if (isInversed == true)
        {
            InverseMovement();
        }
        else
        {
            Movement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Angry"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialAngry;
            speed = 50;
            jumpForce = 1;
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("Joy"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialJoy;
            speed = 10;
            jumpForce = 15;
            other.gameObject.SetActive(false);
        }
        
        if (other.gameObject.CompareTag("Fear"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialFear;
            speed = 15;
            jumpForce = 7;
            //temblar
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Sadness"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialSadness;
            speed = 2;
            jumpForce = 0;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Disgust"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();
            objectRenderer.material = materialDisgust;
            isInversed = true;
            speed = 6;
            jumpForce = 10;
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("RestoreInversionPick"))
        {
            
            other.gameObject.SetActive(false);
        }
    }

    void Movement()
    {
        //velocidad del rigibody = Vector3 (movimiento en X, constante Y, movimiento en Z)
        playerRb.velocity = new Vector3(horInput * speed, playerRb.velocity.y, verInput * speed);
    }

    void InverseMovement()
    {
        playerRb.velocity = new Vector3(horInput * -speed, playerRb.velocity.y, verInput * -speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                isGrounded = false;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
