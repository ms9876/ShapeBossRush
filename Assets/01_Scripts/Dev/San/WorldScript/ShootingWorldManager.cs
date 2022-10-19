using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingWorldManager : WorldForm
{
    [SerializeField] private float moveSpeed = 10;
    KeyCode recentInputKey = KeyCode.None;

    public override void Move(Rigidbody2D rb, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(left) && recentInputKey != right)
        {
            moveDir.x = -1;
            recentInputKey = left;
        }
        else if (Input.GetKey(right) && recentInputKey != left)
        {
            moveDir.x = 1;
            recentInputKey = right;
        }
        else
        {
            recentInputKey = KeyCode.None;
        }

        rb.velocity = moveDir * moveSpeed;

        // ÃÑ¾ËÀ» ½ð´Ù.
        if (Input.GetKeyDown(up))
        {

        }
    }

    public override void Pattern()
    {
        //
    }

    


}
