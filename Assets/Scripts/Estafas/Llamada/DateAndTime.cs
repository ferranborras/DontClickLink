using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DateAndTime : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = DateTime.Now.ToString();
    }
}
