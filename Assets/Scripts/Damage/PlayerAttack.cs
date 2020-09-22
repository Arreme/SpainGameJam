using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private InputSystem input;

    public float maxSpeed = 7f;
    private bool _isAttacking = false;
    private float leftrightcontext;
    private bool facingRight = true;
    private Weapon weapon;
    private Animator animator;
    Rigidbody2D rigid;

    [Header("Horizontal Movement")]
    [SerializeField]
    float fHorizontalAcceleration = 1;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingBasic = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenStopping = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float fHorizontalDampingWhenTurning = 0.5f;


    void Awake()
    {
        input = new InputSystem();
        input.Player1.LeftRight.performed += ctx => LeftRightInput(ctx);
        input.Player1.Attack.performed += ctx => Attack(ctx);
        rigid = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void LeftRightInput(InputAction.CallbackContext ctx)
    {
        leftrightcontext = ctx.ReadValue<float>();
    }

    private void Attack(InputAction.CallbackContext ctx)
    {
        _isAttacking = ctx.ReadValue<float>() == 0 ? false : true;
        /*if (ctx.phase == InputActionPhase.Started) _isAttacking = true;
        if (ctx.phase == InputActionPhase.Canceled) _isAttacking = false;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float fHorizontalVelocity = rigid.velocity.x;
        fHorizontalVelocity += leftrightcontext;

        string animation = "";

        if (_isAttacking)
        {
            weapon.GetComponent<Collider2D>().enabled = true;
            animation = "Attack";
        }
        else weapon.GetComponent<Collider2D>().enabled = false;

        animator.Play(animation);

        if (Mathf.Abs(leftrightcontext) < 0.01f)
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
        else if (Mathf.Sign(leftrightcontext) != Mathf.Sign(fHorizontalVelocity))
        {
            Flip();
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
        }

        else
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);


        if (Mathf.Abs(fHorizontalVelocity) <= maxSpeed)
            rigid.velocity = new Vector2(fHorizontalVelocity, rigid.velocity.y);
        else
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
}
