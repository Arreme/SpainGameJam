using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DarknessChrono : MonoBehaviour
{
    [SerializeField]
    Light2D darkness;
    [SerializeField]
    float startingTime = 10f;
    float currentTime;
    float outer;
    float inner;
    bool charge;
    void Start()
    {
        currentTime = startingTime;
        outer = darkness.pointLightOuterRadius;
        inner = darkness.pointLightInnerRadius;
    }

    void Update()
    {
        float multiplier;
        currentTime -= 1 * Time.deltaTime;
        multiplier = currentTime / startingTime;
        darkness.pointLightOuterRadius = outer * multiplier + 1;
        darkness.pointLightInnerRadius = inner * multiplier + 1;
        if (currentTime <= 0)
        {
            currentTime = 0;

            Debug.Log("Las sombras son mu malas y te matan");
        }
        if (charge)
        {
            if (currentTime < startingTime-0.05)
            {
                currentTime += 2 * Time.deltaTime;
                multiplier = currentTime / startingTime;
                darkness.pointLightOuterRadius = outer * multiplier + 1;
                darkness.pointLightInnerRadius = inner * multiplier + 1;

            } else
            {
                currentTime = startingTime;
            }
            
        }
    }

    public void Reset(bool reset)
    {
        charge = reset;
    }
}
