using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector3 pos;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent.transform as RectTransform,
            Input.mousePosition, transform.parent.GetComponent<Canvas>().worldCamera,
            out movePos);

        Vector3 mousePos = transform.parent.transform.TransformPoint(movePos);

        //Move the Object/Panel
        transform.position = mousePos;
    }
}
