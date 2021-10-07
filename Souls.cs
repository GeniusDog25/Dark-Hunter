using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Souls : MonoBehaviour
{
    //Cantidad de dinero in game a dar
    public float soulsToGive;
    private bool tooked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Colisionador y destructor de items
        if(collision.CompareTag("Player") && tooked == false)
        {
            SkullCounter.instance.Souls(soulsToGive);
            tooked = true;
            Destroy(gameObject);
        }
    }
  
}
