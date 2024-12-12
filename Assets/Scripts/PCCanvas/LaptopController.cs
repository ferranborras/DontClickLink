using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopController : MonoBehaviour
{
    [SerializeField] private GameObject zoomPosition;
    [SerializeField] private MouseController cursor;
    private CameraController cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    void OnMouseOver()
    {
        cam.ZoomIn(zoomPosition.transform.position, 2);
        cursor.ChangeSprite(MouseController.Sprites.cursor);
    }

    void OnMouseExit()
    {
        cam.ZoomOut();
        cursor.ChangeSprite(MouseController.Sprites.finger);
    }
}
