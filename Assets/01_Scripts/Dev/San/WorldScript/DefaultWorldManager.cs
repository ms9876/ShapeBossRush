using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWorldManager : WorldForm
{
    // 기본 플레이어 이동 속도
    [SerializeField] private float _playerSpeed = 0;

    public override void Move(Rigidbody2D rb, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        rb.velocity = Vector3.zero;
        //
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-_playerSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(_playerSpeed, rb.velocity.y);
        }
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(rb.velocity.x, _playerSpeed);
        }
        else if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(rb.velocity.x, -_playerSpeed);
        }
    }

    public override void Pattern()
    {
        //
    }

}
