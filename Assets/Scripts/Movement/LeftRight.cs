using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftRight : MonoBehaviour
{
    Rigidbody2D rgbd;
    InputSystem input;
    [SerializeField]private float maxSpeed = 0;

    void Awake()
    {
        input = new InputSystem();
        rgbd = GetComponent<Rigidbody2D>();
        input.Player1.LeftRight.performed += ctx =>moveLeftRight(ctx);
    }

    private void moveLeftRight(InputAction.CallbackContext ctx)
    {
        rgbd.velocity = new Vector2(ctx.ReadValue<float>() * maxSpeed, rgbd.velocity.y);
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
