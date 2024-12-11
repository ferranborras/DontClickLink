using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject playButton;
    GameObject optionsButton;
    GameObject exitButton;

    public GameObject optionsMenu;
    public GameObject levelChanger;

    void Start()
    {
        playButton = transform.GetChild(0).gameObject;
        optionsButton = transform.GetChild(1).gameObject;
        exitButton = transform.GetChild(2).gameObject;
    }

    public void OnPlayPressed()
    {
        levelChanger.SetActive(true);
        levelChanger.GetComponent<LevelChanger>().FadeToNextLevel();
    }

    public void OnOptionsPressed()
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
