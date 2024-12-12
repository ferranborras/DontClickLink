using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailController : MonoBehaviour
{
    public GameObject content;
    public GameObject correoMalo;
    public GameObject mensajeMalo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState(GameObject window) {
        content.SetActive(content == window);
        correoMalo.SetActive(correoMalo == window);
    }

    public void Eliminar() {
        mensajeMalo.SetActive(false);
    }
}
