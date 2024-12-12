using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    private Vector3 originalPosition;
    private float orginalZoom;

    private Vector3 newPosition;
    private float newZoom;

    [HideInInspector] public bool zoomIn;
    [HideInInspector] public bool zoomOut;

    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float zoomSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        originalPosition = cam.transform.position;
        orginalZoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomIn || zoomOut) {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, newPosition, moveSpeed * Time.deltaTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime * zoomSpeed);
            if (Mathf.Abs(cam.orthographicSize - newZoom) < zoomSpeed * Time.deltaTime)
                cam.orthographicSize = newZoom;

            if (cam.transform.position == newPosition && cam.orthographicSize == newZoom) {
                zoomIn = false;
                zoomOut = false;
            }
        }
    }

    public void ZoomIn(Vector3 pos, float zoom) {
        if (!zoomOut) {
            zoomIn = true;
            zoomOut = false;

            newPosition = pos;
            newPosition.z = originalPosition.z;
            newZoom = zoom;
        }
    }

    public void ZoomOut() {
        if (!zoomIn) {
            zoomIn = false;
            zoomOut = true;

            newPosition = originalPosition;
            newZoom = orginalZoom;
        }
    }
}
