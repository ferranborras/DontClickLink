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
            Debug.Log("Has caído en una estafa");
            //Añadir punto positivo al tablón de anuncios
        }
        else
        {
            Debug.Log("Llamada normal");
            //Activar diálogo corto
        }
        transform.parent.gameObject.GetComponent<CallTimer>().ShowDialog(isFraud);
    }

    public void Hang()
    {
        if (isFraud)
        {
            Debug.Log("Has evitado una llamada estafa");
            //Añadir punto negativo al tablón de anuncios
        }
        transform.parent.gameObject.GetComponent<CallTimer>().ResetTimer();
        Destroy(gameObject);
    }
}
