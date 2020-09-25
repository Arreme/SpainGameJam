using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTriggerDenialDog : MonoBehaviour
{
    [SerializeField]
    Transform dogRespawn;
    [SerializeField]
    Transform darknessRespawn;
    [SerializeField]
    bool darkness;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().Kill();
            GameObject.FindGameObjectWithTag("Dog").transform.position = dogRespawn.transform.position;
            GameObject.FindGameObjectWithTag("Dog").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            if (darkness)
            {
                GameObject.FindGameObjectWithTag("darkness").transform.position = darknessRespawn.transform.position;
                GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().vanish();
                GameObject.FindGameObjectWithTag("darkness").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
                GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().vanish();
                GameObject.FindGameObjectWithTag("darknessEnlarger").GetComponent<DarknessFades>().InvokeRepeating("fadeIn", 0, 0.1f);
            }
            
        }
    }
}
