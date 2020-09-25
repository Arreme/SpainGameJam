using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessFades : MonoBehaviour
{
    SpriteRenderer sprite;
    Color color;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }
    public void vanish()
    {
        color.a = 0f;
    }

    private void fadeIn()
    {
        color.a += 0.05f;
        sprite.color = color;
        if (color.a == 1f)
            StopAllCoroutines();
    }
}
