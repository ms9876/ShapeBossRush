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


}
