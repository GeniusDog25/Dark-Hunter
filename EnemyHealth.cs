using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
    //Variables editables de la vida de los enemigos
    Enemy enemy;
    public bool isDamaged;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    private void Start()
    {
        //Componentes que se llaman al inicio del juego
        enemy = GetComponent<Enemy>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
    }
    //Detector de colisión enemiga con el arma del jugador 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            enemy.healthPoints -= 2f;

            if(collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
            }
           //Corutina sobre la muerte de los enemigos
            StartCoroutine(Damager());
            if (enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);

                Destroy(gameObject); 
            }
        }
    }
    //Método de la corutina para que el enemigo parpadee al recibir daño
    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        sprite.material = material.original;
        isDamaged = false;
    }
}