using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject resumeButton;
    public GameObject quitButton;
    public GameObject restartButton;
    public GameObject background;

    public bool displayed;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Toggle();
    }

    public void Initialize() {
        displayed = false;
        Display();
    }

    public void Toggle() {
        displayed = !displayed;
        Display();
    }

    public void Hide() {
        displayed = false;
        Display();
    }

    public void Display() {
        title.SetActive(displayed);
        resumeButton.SetActive(displayed);
        quitButton.SetActive(displayed);
        restartButton.SetActive(displayed);
        background.SetActive(displayed);
    }
}
