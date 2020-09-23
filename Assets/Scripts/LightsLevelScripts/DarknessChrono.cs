using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessChrono : MonoBehaviour
{
    [SerializeField]
    float startingTime = 10f;
    float currentTime;
    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
       currentTime -= 1 * Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = 0;

            Debug.Log("Las sombras son mu malas y te matan");
        }
    }

    public void Reset()
    {
        currentTime = startingTime;
        Debug.Log("Chrono Rese T.");
    }
}
