using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SecondBoss : WorldObj
{
    Transform playerTrm;

    private void Start()
    {
        playerTrm = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        PoolableMono bullet = PoolManager.Instance.Pop("Bullet_1");
        bullet.transform.position = transform.position;
        Vector2 dir = (playerTrm.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        bullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        bullet.transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle);
    }
}
