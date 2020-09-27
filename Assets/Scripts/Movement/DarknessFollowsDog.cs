using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessFollowsDog : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float darknessSpeedX;
    [SerializeField]
    Transform darknessRespawn;
    [SerializeField]
    Transform dogRespawn;
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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopCoroutine("actualZoomIn");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().offset = new Vector3(0, 3, -20);
            GameObject.FindGameObjectWithTag("Dog").GetComponent<Retreat>().setOver(false);            
            GameObject.FindGameObjectWithTag("Dog").transform.position = dogRespawn.transform.position;
            GameObject.FindGameObjectWithTag("Dog").GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Kill();
            transform.position = darknessRespawn.transform.position;
        }

        if (collision.gameObject.CompareTag("darknessStop"))
        {
            stop = true;
        }
    }
}
