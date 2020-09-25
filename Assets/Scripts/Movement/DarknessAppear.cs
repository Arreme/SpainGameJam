using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAppear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFollows>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
            GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
        }
    }

    
}
