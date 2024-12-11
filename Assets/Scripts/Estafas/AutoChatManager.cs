using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoChatManager : MonoBehaviour
{
    public GameObject[] chat1Messages;
    public GameObject[] chat2Messages;

    List<GameObject> currentChat;
    Queue<GameObject> chatQueue;

    private void Start()
    {
        currentChat = new List<GameObject>();
        chatQueue = new Queue<GameObject>();

        foreach (GameObject message in chat1Messages)
        {
            currentChat.Add(message);
        }

        EnqueueMessages("FriendMessage");
    }

    public void EnqueueMessages(string tag)
    {
        int i = 0;
        while (i < currentChat.Count && currentChat[i].CompareTag(tag))
        {
            chatQueue.Enqueue(currentChat[i]);
            i++;
        }

        foreach (GameObject message in chatQueue)
        {
            currentChat.Remove(message);
        }

        ShowQueuedChat();
    }

    public void ShowQueuedChat()
    {
        foreach (GameObject message in chatQueue)
        {
            message.SetActive(true);
        }
        chatQueue.Clear();

        if (currentChat.Count > 0 && currentChat[0].CompareTag("FriendMessage"))
            EnqueueMessages("FriendMessage");
    }

    public void AnswerButton()
    {
        EnqueueMessages("SelfMessage");
    }
}
