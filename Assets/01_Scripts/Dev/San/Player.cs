using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    None = 0,
    Avoid = 1,
    Tetris = 2,
    Platformer = 3,

}

public class Player : MonoBehaviour
{
    // 플레이어 리지드바디2D
    Rigidbody2D _playerRb = null;

    // 플레이어 현재 보스 화면 유형
    [SerializeField]
    State _playerState = State.None;

    // 플레이어 이동키
    [SerializeField] KeyCode _leftKey = KeyCode.None;
    [SerializeField] KeyCode _rightKey = KeyCode.None;
    [SerializeField] KeyCode _upKey = KeyCode.None;
    [SerializeField] KeyCode _downKey = KeyCode.None;

    // 월드별 이동방식, 패턴들을 구현해둔 스크립트들
    DefaultWorldManager _defaultWorld = null;
    AvoidWorldManager _avoidWorld = null;
    TetrisWorldManager _tetrisWorld = null;
    PlatformerWorldManager _platformerWorld = null;

    private void Awake()
    {
        _playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        _defaultWorld = GetComponentInChildren<DefaultWorldManager>();
        _avoidWorld = GetComponentInChildren<AvoidWorldManager>();
        _tetrisWorld = GetComponentInChildren<TetrisWorldManager>();
        _platformerWorld = GetComponentInChildren<PlatformerWorldManager>();
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
            _defaultWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }
        else if(_playerState == State.Avoid)
        {
            _avoidWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }
        else if(_playerState == State.Tetris)
        {
            _tetrisWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }
        else if(_playerState == State.Platformer)
        {
            _platformerWorld.Move(_playerRb, _leftKey, _rightKey, _upKey, _downKey);
        }

        
    }
}
