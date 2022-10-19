using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None = 0,
    Avoid = 1,
    Shooting = 2,
    Tetris = 3,
    PacMan = 4,

}

public class BossTypePlayerMove : MonoBehaviour
{
    // 플레이어 리지드바디2D
    Rigidbody2D _playerRb = null;

    [Header("플레이어의 월드 상태")]
    [SerializeField]
    State _playerState = State.None;

    [Header("플레이어 이동키")]
    [SerializeField] KeyCode _leftKey = KeyCode.None;
    [SerializeField] KeyCode _rightKey = KeyCode.None;
    [SerializeField] KeyCode _upKey = KeyCode.None;
    [SerializeField] KeyCode _downKey = KeyCode.None;

    // 월드별 이동방식, 패턴들을 구현해둔 스크립트들
    AvoidWorldManager _avoidWorld = null;
    TetrisWorldManager _tetrisWorld = null;
    ShootingWorldManager _platformerWorld = null;

    private void Awake()
    {
        _playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        _avoidWorld = GetComponentInChildren<AvoidWorldManager>();
        _tetrisWorld = GetComponentInChildren<TetrisWorldManager>();
        _platformerWorld = GetComponentInChildren<ShootingWorldManager>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _playerRb.velocity = Vector2.zero;
        if(_playerState == State.None)
        {
            
        }
        else if(_playerState == State.Avoid)
        {
            _avoidWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }
        else if(_playerState == State.Shooting)
        {
            _platformerWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }
        else if(_playerState == State.Tetris)
        {
            _tetrisWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }

        
    }
}
