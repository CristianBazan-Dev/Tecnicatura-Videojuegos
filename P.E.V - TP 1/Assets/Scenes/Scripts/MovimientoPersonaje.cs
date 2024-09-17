using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;

    public int jumpCounts = 0;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(input * movementSpeed, rb.velocity.y);

        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // Le agregué esto nada más porque me puse a experimentar con el aumento de la fuerza del salto 
            jumpCounts++;
            Debug.Log(jumpCounts);
            jumpForce += jumpForce + (jumpForce / jumpCounts);
            Debug.Log(jumpForce);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
