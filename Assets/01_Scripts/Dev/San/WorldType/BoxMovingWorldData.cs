using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovingWorldData : PoolableMono
{
    public Box[] SaveBlockData;

    public override void Reset()
    {
        //
    }

    void Awake()
    {
        SaveBlockData = GetComponentsInChildren<Box>();
    }

    private void FixedUpdate()
    {
        if (WorldManager.instance.WorldState != WorldState.BoxMoving)
        {
            PoolManager.Instance.Push(this);
        }
    }


}
