using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recharger : MonoBehaviour
{
    [SerializeField] DarknessChrono chrono;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            chrono.Reset(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            chrono.Reset(false);
        }
    }
}
