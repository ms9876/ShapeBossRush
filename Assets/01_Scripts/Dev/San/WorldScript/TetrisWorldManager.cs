using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisWorldManager : WorldForm
{

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
