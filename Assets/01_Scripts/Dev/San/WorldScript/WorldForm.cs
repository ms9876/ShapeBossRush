using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldForm : MonoBehaviour
{
    
    public abstract void Move(Rigidbody2D rb, KeyCode left, KeyCode right, KeyCode up, KeyCode down);
    public abstract void Pattern();

    public void DirectionCheck(Rigidbody2D rb)
    {
        if (rb.velocity.x > 0)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (rb.velocity.x < 0)
        {
            rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        
    }

    public bool below = false;
    public void Platformer(float gravity, float jumpPower, Rigidbody2D rb, KeyCode up, LayerMask layerMask)
    {
        //RaycastHit2D hit = Physics2D.CapsuleCast(rb.position, rb.transform.localScale, CapsuleDirection2D.Vertical, 0f, Vector2.down, 0.1f, layerMask);
        //if (hit.collider)
        //{
        //    below = true;
        //}
        //else
        //{
        //    below = false;
        //}

        //if (below) // ¶¥
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, 0);
        //}
        //else // °øÁß
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - (gravity));
        //}

        //if (Input.GetKeyDown(up) && below)
        //{
        //    rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        //}

    }


}
