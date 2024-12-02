using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleWindow : MonoBehaviour
{
    public enum WindowState {
        home,
        results,
        shop,
    }

    public GameObject home;
    public GameObject searchResults;
    public GameObject shopWeb;

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
        shopWeb.SetActive(state == WindowState.shop);
    }
}
