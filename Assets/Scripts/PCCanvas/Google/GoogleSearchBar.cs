using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoogleSearchBar : MonoBehaviour
{
    public TMP_InputField inputField;
    public string simulatedText = "Texto predefinido";

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "";

        inputField.onValueChanged.AddListener(OnTextChanged);
    }

    void OnTextChanged(string userInput)
    {
        if (inputField.caretPosition < simulatedText.Length)
        {
            print(inputField.caretPosition);
            inputField.text = simulatedText.Substring(0, inputField.caretPosition);
        }
        else
            inputField.text = simulatedText;
    }

    public void Search() {
        if (inputField.text.Length == simulatedText.Length) {
            print("cositas");
        }
    }
}
