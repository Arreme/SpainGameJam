using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem input;
    [SerializeField]
    LayerMask lmWalls;
    [SerializeField]
    LayerMask whatIsLadder;
    [SerializeField]
    float ladderRayDist = 0.1f;
    [SerializeField]
    float ladderSpeed = 3f;
    [SerializeField]
    float fJumpVelocity = 5;
    [SerializeField]
    float confusionState = -1f;
    private bool _isJumping;
    private bool _isGrounded;
    private bool _isClimbing;
    private bool _isInteracting;
    private bool facingRight = true;
    private float leftrightcontext;
    private float updowncontext;
   
    Rigidbody2D rigid;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;
       
    [Header("Remember Times")]
    [SerializeField]
    float fJumpPressedRemember = 0;
    [SerializeField]
    float fJumpPressedRememberTime = 0.2f;
    [SerializeField]
    float fGroundedRemember = 0;
    [SerializeField]
    float fGroundedRememberTime = 0.25f;
    private bool _doingLongJump;
    [SerializeField]
    private float timeForLongJump;
    private float timePressed;
    private bool reading;

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

    [SerializeField]
    [Range(0, 1)]
    float fCutJumpHeight = 0.5f;

    [SerializeField]
    private Vector2 positionBox;
    [SerializeField]
    private Vector2 scaleBox;

    void Awake()
    {
        reading = true;
        input = new InputSystem();
        input.Player1.Jump.performed += ctx => JumpInput(ctx);
        input.Player1.LeftRight.performed += ctx => LeftRightInput(ctx);
        input.Player1.UpDown.performed += ctx => UpDownInput(ctx);
        input.Player1.Interact.performed += ctx => InteractInput(ctx);
        rigid = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void JumpInput(InputAction.CallbackContext ctx)
    {
        _isJumping = ctx.ReadValue<float>() == 0 ? false : true;
    }
    private void InteractInput(InputAction.CallbackContext ctx)
    {
        _isInteracting = ctx.ReadValue<float>() == 0 ? false : true;
    }

    private void LeftRightInput(InputAction.CallbackContext ctx)
    {
            leftrightcontext = ctx.ReadValue<float>();
            if ((facingRight && leftrightcontext * -confusionState == -1) || (!facingRight && leftrightcontext * -confusionState == 1))
            {
                Flip();
            }
            
    }

    private void UpDownInput(InputAction.CallbackContext ctx)
    {
        updowncontext = ctx.ReadValue<float>();
    }

        void FixedUpdate()
    {
        Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + positionBox;
        Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + scaleBox;
        _isGrounded = Physics2D.OverlapBox(v2GroundedBoxCheckPosition, v2GroundedBoxCheckScale, 0, lmWalls);
        modifyPhysics();
        fGroundedRemember -= Time.deltaTime;
        if (_isGrounded || _isClimbing)
        {
            fGroundedRemember = fGroundedRememberTime;
            _doingLongJump = false;
        }

        fJumpPressedRemember -= Time.deltaTime;
        if (_isJumping)
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
            timePressed -= Time.deltaTime;
        } else
        {
            if (rigid.velocity.y > 0 && timePressed >= 0.7 && !_doingLongJump)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * fCutJumpHeight);
            } else
            {
                timePressed -= Time.deltaTime;
            }
        }
        if ((fJumpPressedRemember > 0) && (fGroundedRemember > 0))
        {
            fJumpPressedRemember = 0;
            fGroundedRemember = 0;
            rigid.velocity = new Vector2(rigid.velocity.x, fJumpVelocity);
            if (timePressed <= 0)
                _doingLongJump = true;
        }

        float fHorizontalVelocity = rigid.velocity.x;
        fHorizontalVelocity += leftrightcontext * -confusionState;

        if (Mathf.Abs(leftrightcontext) < 0.01f)
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenStopping, Time.deltaTime * 10f);
        else if (Mathf.Sign(leftrightcontext * -confusionState) != Mathf.Sign(fHorizontalVelocity))
        {
            
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingWhenTurning, Time.deltaTime * 10f);
        }
            
        else
            fHorizontalVelocity *= Mathf.Pow(1f - fHorizontalDampingBasic, Time.deltaTime * 10f);

        
        if (Mathf.Abs(fHorizontalVelocity) <= maxSpeed)
            rigid.velocity = new Vector2(fHorizontalVelocity, rigid.velocity.y);
        else
            rigid.velocity = new Vector2(Mathf.Sign(rigid.velocity.x) * maxSpeed, rigid.velocity.y);
        
        RaycastHit2D isLadder = Physics2D.Raycast(transform.position, Vector2.up, ladderRayDist, whatIsLadder);
        
        if (isLadder)
        {
            _isClimbing = true;
            if (updowncontext != 0)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, updowncontext * -confusionState * ladderSpeed);
            }
            else
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
            }
        }
        else
        {
            _isClimbing = false;
        }
    }

    void modifyPhysics()
    {

        if (_isGrounded || _isClimbing)
        {
            rigid.gravityScale = 0;
        }
        else
        {
            rigid.gravityScale = gravity;
            rigid.drag = linearDrag * 0.15f;
            if (rigid.velocity.y < 0)
            {
                rigid.gravityScale = gravity * fallMultiplier;
            }
            else if (rigid.velocity.y > 0 && !_isJumping)
            {
                rigid.gravityScale = gravity * (fallMultiplier / 1.25f);
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }

    public void Confuse()
    {
        confusionState = confusionState * -1;
    }

    public bool getIsInteracting()
    {
        return _isInteracting;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Vector2 v2GroundedBoxCheckPosition = (Vector2)transform.position + positionBox;
    //    Vector2 v2GroundedBoxCheckScale = (Vector2)transform.localScale + scaleBox;
    //    Gizmos.DrawCube(v2GroundedBoxCheckPosition, v2GroundedBoxCheckScale);
    //}
}
