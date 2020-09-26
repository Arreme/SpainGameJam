using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnableDog : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
           GameObject dog = GameObject.FindGameObjectWithTag("Dog");
           dog.GetComponent<Retreat>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
