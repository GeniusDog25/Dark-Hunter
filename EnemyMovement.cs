using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables a usar en el código
    float speed;
    Rigidbody2D rb;
    Animator anim;
    public bool isStatic;
    public bool isWalking;
    public bool walksRight;
    public bool isPatroling;
    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;
    //Detectores de terreno para ubicación de los enemigos 
    public Transform wallCheck, pitCheck, groundCheck;
    bool wallDetected, pitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    bool goToA, goToB;

    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Cada frame el juegi busca detectar si los enemigos colisionan con el terreno 
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

        if (pitDetected || wallDetected && isGrounded)
        {
            //Método para que el enemigo corrija su perspectiva 
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //Movimiento avanzado del enemigo
        //Enemigo estático 
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        //Enemigo caminando
        if (isWalking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatroling)
        {
            anim.SetBool("Idle", false);
            if (goToA)
            {
                //Enemigo esperando en un punto del mapa
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                
                if(Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }
            //Configurador de límites del enemigo
            if (goToB)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
                
                if(Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }
    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    //Corutina de espera de los enemigos al patrullar
    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        Flip();
        anim.SetBool("Idle", false);
    }

}
