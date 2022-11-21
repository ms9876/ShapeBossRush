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

        if(transform.position.y < deleteY)
        {
            PoolManager.Instance.Push(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player"))
        {
            PoolManager.Instance.Push(this);
        }
    }
}
