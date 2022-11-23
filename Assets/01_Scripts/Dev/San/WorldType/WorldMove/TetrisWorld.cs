using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisWorld : WorldType, WorldMove
{
    [SerializeField]
    private List<Vector2> mapMaxAndMin = new List<Vector2>();
    [SerializeField]
    private List<GameObject> mapActiveFalseObj = new List<GameObject>();
    [SerializeField]
    private float speed = 5;
    //슈팅 월드라고 칩시다
    public void DamageCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(PlayerTransform.position, Vector2.up, Player.Colider.radius, DamageAbleLayer);
        if (ray.collider)
        {
            Player.TakeDamage(1);
        }
    }

    public void WorldPlay()
    {
        if (Input.GetKey(UpKey))
        {
            if (mapMaxAndMin[0].y > PlayerTransform.position.y)
            {
                Vector2 pos = PlayerTransform.position;
                pos += Vector2.up * speed * Time.deltaTime;
                PlayerTransform.position = pos;
            }
        }
        if (Input.GetKey(DownKey))
        {
            if (mapMaxAndMin[1].y < PlayerTransform.position.y)
            {
                Vector2 pos = PlayerTransform.position;
                pos += Vector2.down * speed * Time.deltaTime;
                PlayerTransform.position = pos;
            }
        }
        if (Input.GetKey(LeftKey))
        {
            if (mapMaxAndMin[2].x < PlayerTransform.position.x)
            {
                Vector2 pos = PlayerTransform.position;
                pos += Vector2.left * speed * Time.deltaTime;
                PlayerTransform.position = pos;
            }
        }
        if (Input.GetKey(RightKey))
        {
            if (mapMaxAndMin[3].x > PlayerTransform.position.x)
            {
                Vector2 pos = PlayerTransform.position;
                pos += Vector2.right * speed * Time.deltaTime;
                PlayerTransform.position = pos;
            }
        }
    }
    public void WorldSetting()
    {
        foreach(GameObject obj in mapActiveFalseObj)
        {
            obj.SetActive(false);
        }
        StartCoroutine("SummonBullet");
    }
    IEnumerator SummonBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            PoolableMono bullet = PoolManager.Instance.Pop("Bullet");
            bullet.transform.position = PlayerTransform.position;
        }
    }
    IEnumerator BossSummonBullet()
    {
        float x = 8;
        int summonY = 10;
        while (true)
        {
            int rdValue = Random.Range(0, 5); //0~4
            if (rdValue == 0)
            {

            }
            else if (rdValue == 1)
            {

            }
            else if (rdValue >= 2)
            {
                float summonX = Random.Range(-x, x);
                PoolableMono bossBullet = PoolManager.Instance.Pop("bossBullet");
                bossBullet.transform.position = new Vector2(summonX, summonY);
            }
        }
        
    }
}
