using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleWindow : MonoBehaviour
{
    public enum WindowState {
        home,
        results,
        gameWeb,
        badGameWeb,
        webPeor
    }

    public GameObject home;
    public GameObject searchResults;
    public GameObject gameWeb;
    public GameObject badGameWeb;
    public GameObject webPeor;

    private WindowState state;

    // Start is called before the first frame update
    void Start()
    {
        state = WindowState.home;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(WindowState s) {
        state = s;
        home.SetActive(state == WindowState.home);
        searchResults.SetActive(state == WindowState.results);
        gameWeb.SetActive(state == WindowState.gameWeb);
        badGameWeb.SetActive(state == WindowState.badGameWeb);
        webPeor.SetActive(state == WindowState.webPeor);
    }

    public void StateHome() {
        state = WindowState.home;
        ChangeState(state);
    }

    public void StateBadWeb() {
        state = WindowState.badGameWeb;
        ChangeState(state);
    }

    public void StateGameWeb() {
        state = WindowState.gameWeb;
        ChangeState(state);
    }

    public void StateWebPeor() {
        state = WindowState.webPeor;
        ChangeState(state);
    }
}
