using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimeraFase : IBossAtack
{
    [SerializeField]
    Animation anims;
    public void mainAttack()
    {
        anims.Play();
    }

    public override string ToString()
    {
        return "PrimeraFase";
    }
}
