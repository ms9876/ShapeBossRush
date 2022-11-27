using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletFire : WorldObj
{
    Transform playerTrm;
    Vector2 dir;
    public float speed;

    private void OnEnable()
    {
        try
        {
            playerTrm = GameObject.Find("Player").GetComponent<Transform>();
            dir = playerTrm.position - transform.position;
        }
        catch(Exception)
{
            return;
        }
    }

    private void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collider" || collision.tag == "Player")
        {
            PoolManager.Instance.Push(this);
        }
    }
}
