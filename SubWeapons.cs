using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public int usableCost;
    public GameObject arrow;

    private void Update()
    {
        //Cada frame se actualiza el uso de las subarmas
        UseSubWeapon();
    }
    //Método de subarma
    public void UseSubWeapon()
    {
        //Disparar arma usando los usables
        if (Input.GetButtonDown("Fire2") && usableCost <= SubItems.instance.subItemsAmount)
        {
            SubItems.instance.SubItem(-usableCost);
            GameObject subWeapon = Instantiate(arrow, transform.position, Quaternion.Euler(0,0,-132));
            //Dirección y sentido de las subarmas
            if(transform.localScale.x < 0)
            {
                subWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800f, 0f), ForceMode2D.Force);
                subWeapon.transform.localScale = new Vector2(-1, -1);
            }
            else
            {
                subWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f, 0f), ForceMode2D.Force);
            }
        }
    }
}
