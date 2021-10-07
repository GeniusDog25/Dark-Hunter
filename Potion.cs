using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    //Cantidad de vida a dar al personaje
    public float healthToGive;
    private bool tooked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Colisionador con el player y destrucción de item
        if (collision.CompareTag("Player") && tooked == false)
        {
            collision.GetComponent<PlayerHealth>().health += healthToGive;
            tooked = true;
            Destroy(gameObject);
        }
    }
}
