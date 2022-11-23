using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool _noDie = false;

    [SerializeField]
    private GameObject diePanel;

    [SerializeField]
    private int _playerHp = 0;
    [SerializeField]
    private int _currentHp = 0;

    [SerializeField]
    private float _damageDelay = 0.5f;
    bool _canDamage = true;

    [SerializeField]
    private SpriteRenderer _normalSprite;
    [SerializeField]
    private GameObject _ballPlayer;
    [SerializeField]
    private GameObject _boxMovingPlayer;

    [SerializeField]
    private CircleCollider2D _colider;
    public CircleCollider2D Colider => _colider;

    private void Awake()
    {
        _ballPlayer.SetActive(false);
        _boxMovingPlayer.SetActive(false);
        _currentHp = _playerHp;
    }
    public void SetBallPlayer()
    {
        _ballPlayer.SetActive(true);
        _boxMovingPlayer.SetActive(false);
    }
    public void SetBoxPlayer()
    {
        _ballPlayer.SetActive(false);
        _boxMovingPlayer.SetActive(true);
    }
    public void ViewLeft()
    {
        _normalSprite.flipX = true;
    }
    public void ViewRight()
    {
        _normalSprite.flipX = false;
    }
    
    public void TakeDamage(int damage)
    {
        if (_canDamage)
        {
            _currentHp -= damage;
            CameraManager.instance.ShakeCam(0.5f, damage*10);
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
        diePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResetValue()
    {
        _currentHp = _playerHp;
    }
}
