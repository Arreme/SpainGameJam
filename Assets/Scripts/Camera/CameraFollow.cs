using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform trm;
    [Header("Camera Settings")]
    [SerializeField] private float clampSpeed;
    [SerializeField] public Vector3 offset;
    [SerializeField] public float left;
    [SerializeField] public float right;
    [SerializeField] public float bot;
    [SerializeField] public float top;
    

    private Camera cam;
    private float camWidth;
    private float camHeight;
    private float zLock;

    private void Awake()
    {
        zLock = transform.position.z;
    }

    private void Start()
    {
        gameObject.transform.position = trm.position;
        
    }

    void FixedUpdate()
    {
        Vector3 finalPos = trm.position + offset;
        finalPos = Vector3.Lerp(transform.position, finalPos, clampSpeed);
        finalPos = new Vector3(
            Mathf.Clamp(finalPos.x, left, right),
            Mathf.Clamp(finalPos.y, bot, top),
            finalPos.z);
        transform.position = finalPos;
    }

    public void ChangeTarget(GameObject gameObj)
    {
        trm = gameObj.transform;
    }

    
}
