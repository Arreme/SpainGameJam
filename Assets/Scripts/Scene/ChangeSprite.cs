using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{

    [SerializeField]
    private RuntimeAnimatorController animator;
    [SerializeField]
    private Sprite sprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Animator>().runtimeAnimatorController = animator;
            collision.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
