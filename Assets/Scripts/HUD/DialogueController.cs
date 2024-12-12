using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI contentLabel;
    public GameObject nextButton;
    public GameObject background;

    [SerializeField]
    private List<DialogueData> dialogueList;
    public Queue<DialogueData> dialogueQueue;

    // Start is called before the first frame update
    void Start()
    {
        nameLabel.gameObject.SetActive(false);
        contentLabel.gameObject.SetActive(false);
        nextButton.SetActive(false);
        background.SetActive(false);

        EnqueueDialogue();
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetButtonUp("Vertical")) {
            Initialize();
        }
    }*/

    public void EnqueueDialogue()
    {
        dialogueQueue = new Queue<DialogueData>();
        foreach (var dialogue in dialogueList)
        {
            dialogueQueue.Enqueue(dialogue);
        }
    }

    public void Initialize() {
        nameLabel.gameObject.SetActive(true);
        contentLabel.gameObject.SetActive(true);
        nextButton.SetActive(true);
        background.SetActive(true);
        Siguiente();
    }

    public void Siguiente() {
        if (dialogueQueue.Count <= 0) {
            HideDialogue();
            return;
        }
            
        DialogueData current = dialogueQueue.Dequeue();
        nameLabel.text = current.charName;
        contentLabel.text = current.content;
    }

    public void HideDialogue() {
        nameLabel.gameObject.SetActive(false);
        contentLabel.gameObject.SetActive(false);
        nextButton.SetActive(false);
        background.SetActive(false);
    }
}

[System.Serializable]
public class DialogueData
{
    public string charName;
    public string content;

    public DialogueData(string charName, string content) {
        this.charName = charName;
        this.content = content;
    }
}
