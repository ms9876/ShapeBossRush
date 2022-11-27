using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSize : WorldObj  
{
    [SerializeField]
    private Transform bullet;

    private float size = 14.5f;
    public float speed; 

    private float time;
    private Vector2 originScale;

    private void Awake()
    {
        originScale = transform.localScale; 
    }
    private void OnEnable()
    {
        float randValue = UnityEngine.Random.Range(0, 180);
        bullet.localRotation = Quaternion.Euler(bullet.localRotation.x, bullet.localRotation.y, randValue);
        StartCoroutine(Up());
    }
    IEnumerator Up()
    {
        while (transform.localScale.x < size)
        {
            transform.localScale = originScale * (1f + time * speed);
            time += Time.deltaTime;

            if (transform.localScale.x >= size)
            {
                time = 0;
                break;
            }
            yield return null;
        }
        PoolManager.Instance.Pop("Bullet_0");
    }

    private void OnDisable()
    {
        gameObject.transform.localScale = originScale;
    }
}
