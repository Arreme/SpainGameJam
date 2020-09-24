using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform trm;
    [Header("Camera Settings")]
    [SerializeField] private float clampSpeed;
    [SerializeField] public Vector3 offset;
    private 
    void Start()
    {
        gameObject.transform.position = trm.position;
        
    }

    void FixedUpdate()
    {
        Vector3 finalPos = trm.position + offset;
        transform.position = Vector3.Lerp(transform.position, finalPos, clampSpeed);
        
    }

    public void ChangeTarget(GameObject gameObj)
    {
        trm = gameObj.transform;
    }

    
}
