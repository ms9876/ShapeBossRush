using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TetrisWorld : WorldType, WorldMove
{
    [SerializeField]
    private List<Vector2> mapMaxAndMin = new List<Vector2>();
    [SerializeField]
    private List<GameObject> mapActiveFalseObj = new List<GameObject>();
    [SerializeField]
    private List<GameObject> mapActiveTrueObj = new List<GameObject>();
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Transform bossTrm;
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
        foreach(GameObject obj in mapActiveTrueObj)
        {
            obj.SetActive(true);
        }
        StartCoroutine("SummonBullet");
        StartCoroutine("BossSummonBullet");
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
        while (!Player._noDie)
        {
            int rdValue = Random.Range(0, 4); //0~3
            if (rdValue == 0)
            {
                for(int i=0; i<5; i++)
                {
                    PoolableMono bossBullet = PoolManager.Instance.Pop("bossBullet");
                    bossBullet.transform.position = bossTrm.position;
                    bossBullet.transform.rotation = Quaternion.Euler(0, 0, i * 36);
                    PoolableMono bossBullet2 = PoolManager.Instance.Pop("bossBullet");
                    bossBullet2.transform.position = bossTrm.position;
                    bossBullet2.transform.rotation = Quaternion.Euler(0, 0, i * 36 + 90);
                    PoolableMono bossBullet3 = PoolManager.Instance.Pop("bossBullet");
                    bossBullet3.transform.position = bossTrm.position;
                    bossBullet3.transform.rotation = Quaternion.Euler(0, 0, i * 36 + 180);
                    PoolableMono bossBullet4 = PoolManager.Instance.Pop("bossBullet");
                    bossBullet4.transform.position = bossTrm.position;
                    bossBullet4.transform.rotation = Quaternion.Euler(0, 0, i * 36 + 240);
                    yield return new WaitForSeconds(0.1f);
                }  
            }
            else if (rdValue == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    PoolableMono bossBullet = PoolManager.Instance.Pop("bossBullet");
                    bossBullet.transform.position = bossTrm.position;
                    bossBullet.transform.rotation = Quaternion.Euler(0, 0, i * 40);
                }
                yield return new WaitForSeconds(0.2f);
            }
            else if (rdValue >= 2)
            {
                float posX = Random.Range(-x, x);
                bossTrm.DOMoveX(posX, 1f);
                yield return new WaitForSeconds(0.05f);
            }
            
        }
        
    }
}
