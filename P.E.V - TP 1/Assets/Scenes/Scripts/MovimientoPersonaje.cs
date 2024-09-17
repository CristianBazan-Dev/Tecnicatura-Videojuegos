using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    // Ejercicio 4:  Movimiento y Salto de un Personaj
    // Se parte haciendo selección sobre el rigidBody2D de la escena que, en este caso, sería el personaje (Ahí me queda duda de si sería mejor obtener por Tag)
    // Tomando el input horizontal, nativo de Unity C#, aplicamos el Vector2 para darle velocidad sobre ese eje
    // El salto se valida a través del chequeo del isGrounded. Si hay colisión entre el personaje y el piso, dada por el collider, se sabe que el persoanje estará sobre el piso (con tag Ground)

    // Aprovechando que es de tipo booleano, se cambia su estado para, al ingresar el input de salto, se chequee que el personaje está en colisión con el piso.
    // El salto aplica fuerza de salto sobre el eje y, para que el personaje realice el movimiento en esa dirección manteniendose estable sobre el eje x.
    // Añadí de yapa el esbozo de un incrementador de fuerza de salto por conteo de salto (por motivos de experimentación con la funcionalidad)
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
