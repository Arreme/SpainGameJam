﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessFollows : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float darknessSpeedX;
    [SerializeField]
    Transform darknessRespawn;
    bool stop;
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(darknessSpeedX, 0);
        if (stop)
        {
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Kill();
            transform.position = darknessRespawn.transform.position;
        }

        if (collision.gameObject.CompareTag("darknessStop"))
        {
            stop = true;
        }
    }
}
