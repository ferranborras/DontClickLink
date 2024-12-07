using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CallTimer : MonoBehaviour
{
    public Call callScreenPrefab;
    public float timer;
    public GameObject[] dialogs;

    bool ringing;
    int callIndex;
    Call newCall;
    string[] goodCalls = new[] { "Mamá", "Papá", "Mateo", "Amigo" };
    string[] fraudCalls = new[] { "+97 4561 28469 129486", "+34 478 965 124", "79846535476" };

    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
        ringing = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !ringing)
        {
            ringing = true;
            timer = 10;
            newCall = Instantiate(callScreenPrefab, gameObject.GetComponent<RectTransform>().localPosition, Quaternion.identity);
            newCall.transform.SetParent(GetComponent<RectTransform>());
            newCall.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            newCall.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            if (Random.Range(0, 101) > 50)
            {
                newCall.isFraud = true;
                callIndex = Random.Range(0, fraudCalls.Length);
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = fraudCalls[callIndex];
            }
            else
            {
                newCall.isFraud = false;
                callIndex = Random.Range(0, goodCalls.Length);
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = goodCalls[callIndex];
            }
        }

        if (timer <= 0 && ringing && newCall != null)
        {
            newCall.Hang();
        }
    }

    public void ResetTimer()
    {
        timer = Random.Range(120f, 180f);
        ringing = false;
    }

    public void ShowDialog(bool fraud)
    {
        if (fraud)
        {
            if (dialogs[dialogs.Length - 1].GetComponent<DialogueController>().dialogueQueue.Count <= 0)
                dialogs[dialogs.Length - 1].GetComponent<DialogueController>().EnqueueDialogue();

            dialogs[dialogs.Length - 1].GetComponent<DialogueController>().Initialize();
        }
        else
        {
            if (dialogs[callIndex].GetComponent<DialogueController>().dialogueQueue.Count <= 0)
                dialogs[callIndex].GetComponent<DialogueController>().EnqueueDialogue();

            dialogs[callIndex].GetComponent<DialogueController>().Initialize();
        }
    }
}
