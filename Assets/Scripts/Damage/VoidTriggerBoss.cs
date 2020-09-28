using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTriggerBoss : MonoBehaviour
{
    [SerializeField]
    Transform darknessRespawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().Kill();
            if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossAI>().GetComponent<BossHealth>().CurrentHealth == 50)
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