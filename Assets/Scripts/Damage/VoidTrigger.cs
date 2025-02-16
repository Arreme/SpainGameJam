﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().Kill();
        }
    }
}
