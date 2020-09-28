using System.Collections;
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

    void Update()
    {
        rb.velocity = new Vector2(darknessSpeedX, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Kill();
            transform.position = darknessRespawn.transform.position;
        }
    }

}
