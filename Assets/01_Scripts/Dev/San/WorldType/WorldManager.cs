using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WorldState
{
    None = 0,
    Tetris = 1,
    AvoidAndShot = 2,
    BoxMoving = 3,
}


public class WorldManager : MonoBehaviour
{
    //World를 관리하는 뇌 역할의 스크립트
    private Rigidbody2D _playerRigidBody; // 플레이어 리지드바디
    [SerializeField] // 디버깅용 시리얼 라이즈 필드
    private WorldState _worldState; // 현재 월드

    private void Awake()
    {
        _playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

}
