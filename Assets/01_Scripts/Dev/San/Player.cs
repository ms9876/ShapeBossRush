using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _playerHp = 0;
    private int _currentHp = 0;

    [SerializeField]
    private float _damageDelay = 0.5f;
    bool _canDamage = false;

    private SpriteRenderer _playerSprite;
    private CircleCollider2D _colider;
    public CircleCollider2D Colider => _colider;

    private void Awake()
    {
        _playerSprite = GetComponent<SpriteRenderer>();
        _colider = GetComponent<CircleCollider2D>();
    }
    public void ViewLeft()
    {
        _playerSprite.flipX = true;
    }
    public void ViewRight()
    {
        _playerSprite.flipX = false;
    }
    
    public void TakeDamage(int damage)
    {
        if (_canDamage)
        {
            _currentHp -= damage;
            CameraManager.instance.ShakeCam(0.5f, damage);
            StartCoroutine("DamageDelay");
        }
        if(_currentHp <= 0)
        {
            Die();
        }
    }
    IEnumerator DamageDelay()
    {
        _canDamage = false;
        yield return new WaitForSeconds(_damageDelay);
        _canDamage = true;
    }

    private void Die()
    {
        // 죽는 코드
        // 재시작 가능하도록 하기, 나가기
    }

    public void ResetValue()
    {
        _currentHp = _playerHp;
    }
}
