using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerWorldManager : WorldForm
{
    //float _gravity = 10f;
    //[SerializeField] float _jumpPower = 20f;
    //[SerializeField] LayerMask _layermask;

    public override void Move(Rigidbody2D rb, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        //
        DirectionCheck(rb);
    }

    public override void Pattern()
    {
        //
    }

    


}