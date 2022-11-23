using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObj : PoolableMono
{
    [SerializeField]
    WorldState _thisObjWorld = WorldState.None;
    public WorldState thisObjWorld { get { return _thisObjWorld; } set { _thisObjWorld = value; } }

    public override void Reset()
    {
        //
    }

    private void Update()
    {
        if(WorldManager.instance.WorldState != _thisObjWorld)
        {
            PoolManager.Instance.Push(this);
        }
    }
}
