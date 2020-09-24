using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogoJumper : MonoBehaviour
{
    [SerializeField]
    private float JumpForce = 10f;

    public float getForce()
    {
        return JumpForce;
    }
}
