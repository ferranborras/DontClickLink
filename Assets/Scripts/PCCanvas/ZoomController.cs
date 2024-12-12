using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    [SerializeField] private GameObject zoomPosition;
    [SerializeField] private MouseController cursor;
    [SerializeField] private float camZoom;
    private CameraController cam;
    [SerializeField] private bool isLaptop;
    public SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    void OnMouseOver()
    {
        cam.ZoomIn(zoomPosition.transform.position, camZoom);
        cursor.ChangeSprite(isLaptop ? MouseController.Sprites.cursor : MouseController.Sprites.finger);

        if (Input.GetMouseButtonUp(0))
        {
            if (isLaptop)
                sound.PlayClickSound();
            else
                sound.PlayTapSound();
        }
    }

    void OnMouseExit()
    {
        cam.ZoomOut();
        cursor.ChangeSprite(MouseController.Sprites.finger);
    }
}
