using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAppear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject.FindGameObjectWithTag("darkness").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFollows>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
