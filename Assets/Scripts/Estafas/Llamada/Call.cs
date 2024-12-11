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
            transform.parent.gameObject.GetComponent<PhoneScreenManager>().AddPoint(false);
        }

        transform.parent.gameObject.GetComponent<PhoneScreenManager>().ShowDialog(isFraud);
        transform.parent.gameObject.GetComponent<PhoneScreenManager>().ResetTimer();
        Destroy(gameObject);
    }

    public void Hang()
    {
        if (isFraud)
        {
            transform.parent.gameObject.GetComponent<PhoneScreenManager>().AddPoint(true);
        }

        transform.parent.gameObject.GetComponent<PhoneScreenManager>().ResetTimer();
        Destroy(gameObject);
    }
}
