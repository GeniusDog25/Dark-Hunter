using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int usable;
    private bool tooked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Colisionador de usables y su contador
        if (collision.CompareTag("Player") && tooked == false)
        {
            //Detecta si el item ya se tomó y lo elimina si fue así
            SubItems.instance.SubItem(usable);
            tooked = true;
            Destroy(gameObject);
        }
    }

}
