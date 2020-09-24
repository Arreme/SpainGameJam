using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatCam : MonoBehaviour
{
    [SerializeField] private CameraFollow cam;
    void Start()
    {
        Retreat.current.onTimeFinish += zoomIn;
    }
    void Update()
    {
        if (cam.offset.z >= -10)
        {
            CancelInvoke();
        }
    }

    private void zoomIn()
    {
        InvokeRepeating("actualZoomIn", 0, 0.2f);
    }

    private void actualZoomIn()
    {
        cam.offset = new Vector3(cam.offset.x + 0.015f, cam.offset.y - 0.05f, cam.offset.z + 0.75f);
    }

}
