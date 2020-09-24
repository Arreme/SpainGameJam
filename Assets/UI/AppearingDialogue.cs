using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppearingDialogue : MonoBehaviour
{
    [SerializeField] private Image customImage;
    [SerializeField] private TextMeshProUGUI customText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            customImage.enabled = true;
            customText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            customImage.enabled = false;
            customText.enabled = false;
        }

    }
}
