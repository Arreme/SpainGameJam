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
    }

    public event Action onTimeFinish;
    public void onTImeFinish()
    {
        onTimeFinish?.Invoke();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!endRun)
        {
            if (!boosted)
            {
                rb.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                rb.velocity = new Vector2(Mathf.Min(rb.velocity.x, maxSpeed), rb.velocity.y);
            }
            if (over)
            {
                maxSpeed = Mathf.Max(maxSpeed -= 0.01f, 0);
                if (!done)
                {
                    onTImeFinish();
                    done = true;
                }
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().getIsInteracting())
                {
                    Debug.Log("Hey");
                    StopCoroutine("actualZoomIn");

                    InvokeRepeating("fadeAway", 0, 0.2f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("dogJumper"))
        {
            rb.AddForce(new Vector2(0, collision.gameObject.GetComponent<DogoJumper>().getForce()), ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("dogEndRun"))
        {
            over = true;
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
