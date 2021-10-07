using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //Nombre de variables sobre la vida del personaje 
    public float health;
    public float maxHealth;
    public Image healthImg;
    bool isInmune;
    public float inmunity;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;

    
    void Start()
    {
        
        //Se llama al inicio del juego Componentes esenciales
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    // Detector de vida del personaje cada frame
    void Update()
    {
        healthImg.fillAmount = health / 100;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    //Colisionador con enemigos y tiempo inmune
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());  

            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            if(health <= 0)
            {
                //se detiene el tiempo de juego y se llama a la escena de muerte
                Time.timeScale = 0;
                SceneManager.LoadScene("dieScene");
                //Destroy(gameObject);
            }
        }
    }
    //Corutina de inmunidad al entrar en contacto con un enemigo
    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunity);
        sprite.material = material.original;
        isInmune = false;
    }
}



