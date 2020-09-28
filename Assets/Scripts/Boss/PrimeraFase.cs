using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraFase : IBossAtack
{
    private List<Animation> anims;
    public PrimeraFase(List<Animation> animations)
    {
        anims = animations;
    }
    public void mainAttack()
    {
        int number = Random.Range(0, 4);
        Animation anim = anims[number];
        anim.Play();
    }

    public override string ToString()
    {
        return "PrimeraFase";
    }
}
