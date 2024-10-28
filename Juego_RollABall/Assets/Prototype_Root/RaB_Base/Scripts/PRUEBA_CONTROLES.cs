using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBA_CONTROLES : MonoBehaviour
{

    [Header("Public References")]
    public Rigidbody playerRb; // Variable para referenciar el Rigibody del jugador, y así modificarlo cuando quiera por código

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
        if (other.gameObject.CompareTag("InversePick"))
        {
            isInversed = true;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("RestoreInversionPick"))
        {
            isInversed = false;
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
