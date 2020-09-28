using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject wallL;
    [SerializeField]
    private GameObject wallR;
    [SerializeField]
    private GameObject portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wallL.SetActive(true);
            wallR.SetActive(true);
           portal.SetActive(true);
        }   

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (portal.GetComponent<SpriteRenderer>().enabled == false)
            {
                wallL.SetActive(false);
                wallR.SetActive(false);
            }
        }
    }
}
