using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    Vector3 pos;

    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject finger;
    [SerializeField] private GameObject hand;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public enum Sprites {
        cursor,
        finger,
        hand
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

    public void ChangeCursorSprite(Sprites sprite) {
        cursor.SetActive(sprite == Sprites.cursor);
        finger.SetActive(sprite == Sprites.finger);
        hand.SetActive(sprite == Sprites.hand);
    }
}
