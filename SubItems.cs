using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubItems : MonoBehaviour
{
    //Cantidad de usable total
    public Text subItemsText;
    public int subItemsAmount;
    

    public static SubItems instance;
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
        //Cantidad de usables al inicio de juego = 0
        subItemsText.text = "x " +  subItemsAmount.ToString();
    }

    public void SubItem(int subItemAmount)
    {
        //Acumulador de usables
        subItemsAmount += subItemAmount;
        subItemsText.text = "x " + subItemsAmount.ToString();
    }
    
}
