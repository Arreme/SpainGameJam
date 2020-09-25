using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{

    public static Retreat current;
    Rigidbody2D rb;
    private bool boosted;
    private bool over;
    [SerializeField]
    private float maxSpeed;
    private bool done;
    private bool endRun;
    SpriteRenderer sprite;
    Color color;
    [SerializeField]
    Animator dogAnimator;
    void Awake()
    {
        over = false;
        rb = GetComponent<Rigidbody2D>();
        boosted = false;
        maxSpeed = 9;
        current = this;
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        done = false;
        endRun = false;
    }

    public event Action onTimeFinish;
    public void onTImeFinish()
    {
        onTimeFinish?.Invoke();
    }

    void FixedUpdate()
    {
            if (!boosted)
            {
            dogAnimator.SetBool("Idle", false);
            dogAnimator.SetBool("Running", true);
            dogAnimator.SetBool("Jumping", false);
            
            rb.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxSpeed), rb.velocity.y);
            }
            if (over)
            {
                maxSpeed = Mathf.Max(maxSpeed -= 0.01f, 0);
                if(endRun)
                {
                    maxSpeed = 0;
                    dogAnimator.SetBool("Idle", true);
                    dogAnimator.SetBool("Running", false);
                    dogAnimator.SetBool("Jumping", false);
                    if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getIsInteracting() &&
                    GameObject.FindGameObjectWithTag("PlayerNear").GetComponent<PlayerNear>().getPlayerIsNear())
                    {
                         StopCoroutine("actualZoomIn");

                         InvokeRepeating("fadeAway", 0, 0.2f);
                    }


            }
                if (!done)
                {
                    onTImeFinish();
                    done = true;
                
                 }
                
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dogJumper"))
        {
            rb.AddForce(new Vector2(0, collision.gameObject.GetComponent<DogoJumper>().getForce()), ForceMode2D.Impulse);
            dogAnimator.SetBool("Idle", false);
            dogAnimator.SetBool("Running", false);
            dogAnimator.SetBool("Jumping", true);
        }
        if (collision.gameObject.CompareTag("dogOver"))
        {
            over = true;
        }
        if (collision.gameObject.CompareTag("dogEndRun"))
        {
            endRun = true;

        }
    }
    private void fadeAway()
    {
        color.a -= 0.1f;
        sprite.color = color;
        if (color.a == 0f)
            StopAllCoroutines();
    }

}
