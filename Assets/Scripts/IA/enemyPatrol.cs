using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    Rigidbody2D rb2d;
    enemyContacts enemyContacts;

    [SerializeField]
    float speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyContacts = GetComponent<enemyContacts>();
    }


    void Update()
    {
        if (enemyContacts.wallContact || !enemyContacts.canNextStep || enemyContacts.playerBehindHit)
        {
            transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
        }
        rb2d.velocity = new Vector2(Time.fixedDeltaTime * speed * transform.right.x, rb2d.velocity.y);
    }
}
