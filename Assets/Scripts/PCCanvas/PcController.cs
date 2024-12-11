using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcController : MonoBehaviour
{
    public GameObject desktop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Display(GameObject window) {
        GameObject child;
        WindowController childScript;
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            childScript = child.GetComponent<WindowController>();
            if (childScript != null) {
                childScript.Display(child == window);
            }
        }
    }
}
