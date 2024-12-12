using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcController : MonoBehaviour
{
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

    public void EndScene() {
        Cursor.visible = true;
        SceneManager.LoadScene("EndScene");
    }
}
