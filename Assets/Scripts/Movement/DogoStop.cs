using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoStop : MonoBehaviour
{
    [SerializeField]
    Animator dogAnimator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Dog"))
        {
            collision.gameObject.GetComponent<Retreat>().enabled = false;
            dogAnimator.SetBool("Idle", true);
            dogAnimator.SetBool("Running", false);
            dogAnimator.SetBool("Jumping", false);
        }
    }
}
