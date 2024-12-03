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
        }
        else
        {
            Debug.Log("Llamada normal");
        }
    }

    public void Hang()
    {
        if (isFraud)
        {
            Debug.Log("Has evitado una llamada estafa");
        }
        else
        {
            Debug.Log("Has colgado una llamada buena");
        }
        transform.parent.gameObject.GetComponent<CallTimer>().ResetTimer();
        Destroy(gameObject);
    }
}
