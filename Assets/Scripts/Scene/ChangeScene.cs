using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string nextStage;

    [SerializeField]
    public Image image;
    [SerializeField]
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isReading = true;
            collision.GetComponent<PlayerController>().leftrightcontext = 0;
            collision.GetComponent<PlayerController>().updowncontext = 0;
        }            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            image.enabled = true;
            animator.SetBool("isActive", true);
            
            if (collision.GetComponent<PlayerController>()._isInteracting)
            {               
                SceneManager.LoadScene(nextStage);
            }
            
        }
    }
}
