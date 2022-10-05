using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisWorldManager : WorldForm
{
    float _gravity = 0.98f;
    [SerializeField] float _jumpPower = 20f;
    [SerializeField] LayerMask _layermask;

    public override void Move(Rigidbody2D rb, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        //
        Platformer(_gravity, _jumpPower, rb, up, _layermask);
        DirectionCheck(rb);
    }

    public override void Pattern()
    {
        //
    }
}
