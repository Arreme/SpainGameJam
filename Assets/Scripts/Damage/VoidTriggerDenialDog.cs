using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTriggerDenialDog : MonoBehaviour
{
    [SerializeField]
    Transform dogRespawn;
    [SerializeField]
    Transform darknessRespawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealthSystem>().Kill();
            GameObject.FindGameObjectWithTag("Dog").transform.position = dogRespawn.transform.position;
            GameObject.FindGameObjectWithTag("darkness").transform.position = darknessRespawn.transform.position;
        }
    }
}
