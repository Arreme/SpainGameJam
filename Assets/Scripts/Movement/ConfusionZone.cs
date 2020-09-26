using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ConfusionZone : MonoBehaviour
{
    [SerializeField] Volume volume;
    ChromaticAberration chrom;
    private void Start()
    {
        ChromaticAberration tmp;
        if (volume.profile.TryGet(out tmp))
        {
            chrom = tmp;
        }
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            yield return new WaitForSeconds(0.4f);
            collision.gameObject.GetComponent<PlayerController>().ConfuseActivate();
            StopAllCoroutines();
            StartCoroutine(DoChrome());
            
        }
    }

    private IEnumerator OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            yield return new WaitForSeconds(0.4f);
            collision.gameObject.GetComponent<PlayerController>().ConfuseDeactivate();
            StopAllCoroutines();
            StartCoroutine(DontChrome());
            
        }
    }

    private IEnumerator DoChrome()
    {
        for (float i = chrom.intensity.GetValue<float>() ; i < 1; i = i + 0.2f)
        {
            chrom.intensity.SetValue(new FloatParameter(i,false));
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    private IEnumerator DontChrome()
    {
        for (float i = chrom.intensity.GetValue<float>(); i > 0; i = i - 0.2f)
        {
            chrom.intensity.SetValue(new FloatParameter(i, false));
            yield return new WaitForSeconds(0.1f);
        }

    }
}
