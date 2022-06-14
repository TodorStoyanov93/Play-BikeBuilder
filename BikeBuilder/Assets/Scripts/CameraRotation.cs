using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;

    private Vector3 mousePos;

    private float camDistance = -10;
    private float camHeight = 0;

    void Start()
    {
        cam.transform.position = target.position;

        cam.transform.Translate(new Vector3(0, camHeight, camDistance));
    }

    // Update is called once per frame
    void Update()
    {
        Zoom();
        Rotate();

    }

    private void Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
            
        }

        if (Input.GetMouseButton(0))
        {
            var mousePosChange = mousePos - cam.ScreenToViewportPoint(Input.mousePosition);


            cam.transform.position = target.position;

            camHeight += mousePosChange.y;
            camHeight = Mathf.Clamp(camHeight, -2, 2);
            //cam.transform.Rotate(new Vector3(1, 0, 0), mousePosChange.y * 180);
            cam.transform.Rotate(new Vector3(0, 1, 0), -mousePosChange.x * 180, Space.World);
            cam.transform.Translate(new Vector3(0, camHeight, camDistance));
            

            mousePos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    private void Zoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            camDistance += Input.mouseScrollDelta.y * .5f;
            camDistance = Mathf.Clamp(camDistance, -13, -7);
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0, camHeight, camDistance));
        }
    }
}
