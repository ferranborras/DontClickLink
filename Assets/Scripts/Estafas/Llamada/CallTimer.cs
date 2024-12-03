using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CallTimer : MonoBehaviour
{
    public Call callScreenPrefab;
    public float timer;

    bool countDown;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10;
        countDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDown)
            timer -= Time.deltaTime;

        if (timer <= 0 && countDown)
        {
            countDown = false;
            Call newCall;
            newCall = Instantiate(callScreenPrefab, gameObject.GetComponent<RectTransform>().localPosition, Quaternion.identity);
            newCall.transform.SetParent(GetComponent<RectTransform>());
            if (Random.Range(0, 101) > 50)
            {
                newCall.isFraud = true;
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = "Desconocido";
            }
            else
            {
                newCall.isFraud = false;
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = "Mamá";
            }
        }
    }

    public void ResetTimer()
    {
        timer = Random.Range(60f, 120f);
    }
}
