using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Animator button;
    public Image image;
    public GameObject spirit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().isReading = true;
            collision.GetComponent<PlayerController>().leftrightcontext = 0;
            collision.GetComponent<PlayerController>().updowncontext = 0;
            image.enabled = true;
            button.SetBool("isActive", true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>().Heal(100);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isReading = false;
            spirit.SetActive(false);
            image.enabled = false;
            button.SetBool("isActive", false);
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

}
