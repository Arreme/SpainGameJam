using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNear : MonoBehaviour
{
    bool playerIsNear;
    [SerializeField] public Image image;
    [SerializeField] public Animator animator;
    [SerializeField] public AudioSource source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            image.enabled = true;
            collision.GetComponent<PlayerController>().isReading = true;
            collision.GetComponent<PlayerController>().leftrightcontext = 0;
            collision.GetComponent<PlayerController>().updowncontext = 0;
            animator.SetBool("isActive", true);
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            image.enabled = false;
            source.Stop();
            animator.SetBool("isActive", false);
            playerIsNear = false;
        }
    }

    public bool getPlayerIsNear()
    {
        return playerIsNear;
    }

}
