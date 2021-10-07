using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverse : MonoBehaviour
{
    //Variables necesarias para que los enemigos ataquen a distancia
    public GameObject projectile;
    public float timeToShoot;
    public float shootCoolDown;
    public bool frecuentShooter;
    public bool watcher;

    private void Start()
    {
        //Al inicio se iguala el tiempo para disparar con su enfriamiento
        shootCoolDown = timeToShoot;
    }
    private void Update()
    {
        //Si el enemigo dispara siempre, depende de cooldown
        if (frecuentShooter)
        {
            shootCoolDown -= Time.deltaTime;

            if (shootCoolDown < 0)
            {
                Shoot();
            }
        }
        //El enemigo dispara dependiendo del rango donde entre el jugador
        if (watcher)
        {

        }
    }
    //Método de disparo
    public void Shoot()
    {
        GameObject Bone = Instantiate(projectile, transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            Bone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 0), ForceMode2D.Force);
        }
        else
        {
            Bone.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 0), ForceMode2D.Force);
        }
        shootCoolDown = timeToShoot;
    }
}
