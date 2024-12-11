using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    private Vector3 originalPosition;
    private float originalSize;

    public bool zoomIn;
    public bool zoomOut;

    private Vector3 newPosition;
    private float newSize;

    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float moveSpeed = 1f;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        originalPosition = transform.position;
        originalSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomIn || zoomOut) {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, zoomSpeed * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newSize, Time.deltaTime * moveSpeed);
            if (Mathf.Abs(cam.orthographicSize - newSize) < moveSpeed * Time.deltaTime)
                cam.orthographicSize = newSize;

            if (transform.position == newPosition && cam.orthographicSize == newSize) {
                zoomOut = false;
                zoomIn = false;
            }
        }
    }

    public void ZoomIn(Vector3 pos, float s) {
        zoomOut = false;
        zoomIn = true;
        newPosition = pos;
        newPosition.z = originalPosition.z;
        newSize = s;
    }

    public void ZoomOut() {
        zoomOut = true;
        zoomIn = false;
        newPosition = originalPosition;
        newSize = originalSize;
    }
}
