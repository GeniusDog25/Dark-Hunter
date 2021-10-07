using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullCounter : MonoBehaviour
{
    //Cantidad de Calaveras del jugador
    public float skull;
    public Text soulsText;

    public static SkullCounter instance;

    private void Awake()
    {
        //Detector de null
        if(instance == null)
        {
            instance = this;
        }

    }

    private void Start()
    {
        //Cantidad de calaveras en la interfaz de usuario = 0
        soulsText.text = "x " + skull.ToString();
    }

    public void Souls(float skullsCollected)
    {
        //Acumulador de calaveras
        skull += skullsCollected;
        soulsText.text = "x " + skull.ToString();
    }
   
}
