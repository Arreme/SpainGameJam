using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject wallL;
    [SerializeField]
    private GameObject wallR;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wallL.SetActive(true);
            wallR.SetActive(true);
        }     

    }
}
