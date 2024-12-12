using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneScreenManager : MonoBehaviour
{
    public Call callScreenPrefab;
    public float timer;
    public GameObject[] dialogs;
    public GameObject callTextPrefab;
    public GameObject callList;
    public GameObject[] phoneScreens;
    public Sprite[] callIcons, pixtagramIcons;
    public PointManager pointsTable;

    public GameObject ringingAlert;

    bool ringing;
    int callIndex;
    Call newCall;
    string[] goodCalls = new[] { "Mamá", "Papá", "Mateo", "Amigo" };
    string[] fraudCalls = new[] { "+97 4561 28469 129486", "+34 478 965 124", "79846535476" };

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        ringing = false;
        ringingAlert.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && !ringing)
        {
            GameObject newCallText;
            ringing = true;
            ringingAlert.SetActive(true);
            timer = 10;
            newCall = Instantiate(callScreenPrefab, gameObject.GetComponent<RectTransform>().localPosition, Quaternion.identity);
            newCall.transform.SetParent(GetComponent<RectTransform>());
            newCall.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
            newCall.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

            newCallText = Instantiate(callTextPrefab, Vector3.zero, Quaternion.identity);
            newCallText.transform.SetParent(callList.GetComponent<RectTransform>());
            newCallText.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);

            if (Random.Range(0, 101) > 50)
            {
                newCall.isFraud = true;
                callIndex = Random.Range(0, fraudCalls.Length);
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = fraudCalls[callIndex];
                newCallText.GetComponent<TextMeshProUGUI>().text = fraudCalls[callIndex];
            }
            else
            {
                newCall.isFraud = false;
                callIndex = Random.Range(0, goodCalls.Length);
                newCall.callerText.GetComponent<TextMeshProUGUI>().text = goodCalls[callIndex];
                newCallText.GetComponent<TextMeshProUGUI>().text = goodCalls[callIndex];
            }

            if (phoneScreens[0].transform.GetChild(1).GetComponent<Button>().image.sprite == callIcons[0])
            {
                phoneScreens[0].transform.GetChild(1).GetComponent<Button>().image.sprite = callIcons[1];
            }
        }

        if (timer <= 0 && ringing && newCall != null)
        {
            newCall.Hang();
        }
    }

    public void ResetTimer()
    {
        timer = Random.Range(20f, 40f);
        ringing = false;
        ringingAlert.SetActive(false);
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

    public void ShowCallsScreen()
    {
        phoneScreens[1].SetActive(true);
        if (phoneScreens[0].transform.GetChild(1).GetComponent<Button>().image.sprite == callIcons[1])
        {
            phoneScreens[0].transform.GetChild(1).GetComponent<Button>().image.sprite = callIcons[0];
        }
    }

    public void ShowContactsScreen()
    {
        phoneScreens[2].SetActive(true);
    }

    public void ShowPixtagramScreen()
    {
        phoneScreens[3].SetActive(true);
        if (phoneScreens[0].transform.GetChild(3).GetComponent<Button>().image.sprite == pixtagramIcons[1])
        {
            phoneScreens[0].transform.GetChild(3).GetComponent<Button>().image.sprite = pixtagramIcons[0];
        }
    }

    public void BackToMain(int index)
    {
        phoneScreens[index].SetActive(false);
    }

    public void AddPoint(bool positive)
    {
        pointsTable.AddPoint(positive, 1);
    }
}
