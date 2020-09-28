using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegonaFase : IBossAtack
{
    List<Transform> trfs;
    List<CircleCollider2D> cllds;
    int number = 0;
    public SegonaFase(List<Transform> trf,List<CircleCollider2D> clld)
    {
        trfs = trf;
        this.cllds = clld;
    }
    public void mainAttack()
    {
        cllds[number].enabled = false;
        number = Random.Range(0, 4);
        cllds[number].enabled = true;
    }

    public override string ToString()
    {
        return "SegonaFase";
    }
}
