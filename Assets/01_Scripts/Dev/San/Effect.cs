using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : PoolableMono
{
    [SerializeField]
    private float _stageValue;
    public float StageValue => _stageValue;
    
    public override void Reset()
    {
        //
    }
}
