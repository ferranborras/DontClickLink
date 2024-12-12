using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputBar : MonoBehaviour
{
    public TMP_InputField inputField;
    public string simulatedText = "Texto predefinido";

    void Start()
    {
        inputField.text = "";
        inputField.onValueChanged.AddListener(OnTextChanged);
    }

    void OnTextChanged(string userInput)
    {
        if (inputField.caretPosition < simulatedText.Length)
        {
            inputField.text = simulatedText.Substring(0, inputField.caretPosition);
            inputField.caretPosition = inputField.text.Length;
        }
        else
            inputField.text = simulatedText;
    }

    public void Search(GoogleWindow googleScript) {
        if (inputField.text.Length == simulatedText.Length) {
            googleScript.ChangeState(GoogleWindow.WindowState.results);
        }
    }
}
