using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFades : MonoBehaviour
{
    SpriteRenderer sprite;
    Color color;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
    }
    void Update()
    {
        
    }
    private void fadeIn()
    {
        color.a += 0.05f;
        sprite.color = color;
        if (color.a == 1f)
            StopAllCoroutines();
    }
}
