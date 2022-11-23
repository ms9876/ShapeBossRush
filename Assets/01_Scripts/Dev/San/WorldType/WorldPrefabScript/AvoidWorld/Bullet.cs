using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : WorldObj
{
    [SerializeField]
    private float downSpeed = 5;

    private float deleteY = -7;

    private void Update()
    {
        transform.position += Vector3.down * downSpeed * Time.deltaTime;

        if ((transform.position.y < deleteY && thisObjWorld != WorldState.Tetris) || transform.position.y > 10)
        {
            PoolManager.Instance.Push(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("BossYellow"))
        {
            PoolManager.Instance.Push(this);
        }
    }

}
