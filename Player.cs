using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Se declaran los nombres de las variablesa usar
    public float speed, jumpHeight;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;


    // Start llama al inicio del juego al Rigidbody y al Animator
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Se actualiza una vez por frame en el juego
    void Update()
    {
        //Detector de contacto del jugador con el suelo 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        FlipCharacter();
        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }
        Attack();

    }
    private void FixedUpdate()
    {
        //Métodos del código
        Movement();
        Jump();
    }
    //Movimiento básico del jugador 
    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, velY);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
    //Código para voltear la perspectiva del personaje
    public void FlipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, 1);
        }
        else if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        }
    }
    //Método de salto
    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
    //Método de ataque 
    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
        
    }
}
