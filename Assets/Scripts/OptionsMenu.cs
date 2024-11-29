using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    GameObject backButton;

    public GameObject mainMenu;

    void Start()
    {
        backButton = transform.GetChild(0).gameObject;
    }

    public void OnBackPressed()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
