using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField]
    GameObject objeto;
    [SerializeField]
    Transform trf;
    [SerializeField]
    Slider sld;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(objeto, trf.position,Quaternion.identity);
        
    }
}
