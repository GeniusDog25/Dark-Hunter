using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    //Detector de colisión con rango de ataque del enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.GetComponentInParent<EnemyProjectile>().watcher == true)
        {
            transform.GetComponentInParent<EnemyProjectile>().Shoot(); 
        }
    }
}
