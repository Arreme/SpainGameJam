using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Torch"))
        {
            DarknessChrono dkc = this.gameObject.GetComponent<DarknessChrono>();
            dkc.Reset();
        }
    }
}
