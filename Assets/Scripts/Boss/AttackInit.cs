using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInit
{

    public static IBossAtack generateAttack(string name)
    {
        if (name.Equals("SegonaFase"))
        {
            return null;
        } else if (name.Equals("TerceraFase"))
        {
            return new TerceraFase();
        } else
        {
            return new LastFase();
        }
    }
}
