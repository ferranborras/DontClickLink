using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Call : MonoBehaviour
{
    public GameObject pickUpButton;
    public GameObject hangButton;
    public GameObject callerText;
    public bool isFraud;

    public void PickUp()
    {
        if (isFraud)
        {
            Debug.Log("Has ca�do en una estafa");
            //A�adir punto positivo al tabl�n de anuncios
        }
        else
        {
            Debug.Log("Llamada normal");
            //Activar di�logo corto
        }
        transform.parent.gameObject.GetComponent<CallTimer>().ShowDialog(isFraud);
    }

    public void Hang()
    {
        if (isFraud)
        {
            Debug.Log("Has evitado una llamada estafa");
            //A�adir punto negativo al tabl�n de anuncios
        }
        transform.parent.gameObject.GetComponent<CallTimer>().ResetTimer();
        Destroy(gameObject);
    }
}
