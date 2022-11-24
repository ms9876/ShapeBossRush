using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpriteRenderer _bossSprite;
    private bool _canDamage = true;
    [SerializeField]
    private int bossHp = 50;
    [SerializeField]
    private GameObject clearEffect;
    [SerializeField]
    private GameObject clearPanel;

    private void Awake()
    {
        _bossSprite = GetComponent<SpriteRenderer>();
    }

    public void DamageCheck()
    {
        if (_canDamage)
        {
            CameraManager.instance.ShakeCam(0.05f, 50);
            StopCoroutine("Damage");
            StartCoroutine("Damage");
        }
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Bullet"))
        {
            DamageCheck();
        }
    }

    IEnumerator Damage()
    {
        _canDamage = false;
        _bossSprite.color = Color.red;
        
        yield return new WaitForSeconds(0.1f);
        _bossSprite.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        bossHp--;
        if(bossHp <= 0)
        {
            Clearing();
        }
        _canDamage = true;
    }
    private void Clearing()
    {
        clearEffect.SetActive(true);
        Player._noDie = true;
        _bossSprite.enabled = false;
        StartCoroutine("ClearPanel");
    }
    IEnumerator ClearPanel()
    {
        yield return new WaitForSeconds(1f);
        clearPanel.SetActive(true);
        _bossSprite.gameObject.SetActive(false);
    }
}
