using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegonaFase : IBossAtack
{
    public SegonaFase(List<Transform> trf)
    {
        trf.ForEach(x => x.position = new Vector3(x.position.x, 3.47f,x.position.z));
    }
    public void mainAttack()
    {
        
    }

    public override string ToString()
    {
        return "SegonaFase";
    }
}
