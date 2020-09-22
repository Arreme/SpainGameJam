using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform trm;
    [Header("Camera Settings")]
    [SerializeField] private float clampSpeed;
    [SerializeField] private Vector3 offset;
    private 
    void Start()
    {
        gameObject.transform.position = trm.position;
        Retreat.current.onTimeFinish += zoomIn;
    }

    void FixedUpdate()
    {
        Vector3 finalPos = trm.position + offset;
        transform.position = Vector3.Lerp(transform.position, finalPos, clampSpeed);
        if (offset.z >= -10)
        {
            CancelInvoke();
        }
    }

    public void ChangeTarget(GameObject gameObj)
    {
        trm = gameObj.transform;
    }

    private void zoomIn()
    {
        InvokeRepeating("actualZoomIn", 0, 3);
    }

    private void actualZoomIn()
    {
        Debug.Log("Hey");
        offset = new Vector3(offset.x + 0.00015f,offset.y-0.002f, offset.z + 0.035f);
        
    }
}
