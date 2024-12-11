using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopCollider : MonoBehaviour
{
    [SerializeField] private GameObject zoomPosition;
    [SerializeField] private MouseController cursor;
    private Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (!cam.gameObject.GetComponent<CamController>().zoomOut) {
            cam.gameObject.GetComponent<CamController>().ZoomIn(zoomPosition.transform.position, 2);
            cursor.ChangeCursorSprite(MouseController.Sprites.cursor);
        }
    }

    void OnMouseExit()
    {
        if (!cam.gameObject.GetComponent<CamController>().zoomIn) {
            cam.gameObject.GetComponent<CamController>().ZoomOut();
            cursor.ChangeCursorSprite(MouseController.Sprites.finger);
        }
    }
}
