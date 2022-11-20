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
    [SerializeField] // 디버깅용 시리얼 라이즈 필드
    private WorldState _worldState; // 현재 월드

    private WorldMove _currentWorld;

    private void Update()
    {
        if(_currentWorld != null)
        {
            _currentWorld.WorldPlay();
            _currentWorld.DamageCheck();

        }
    }

    public void ChangeWorld(WorldMove game, WorldState state)
    {
        _currentWorld = game;
        _worldState = state;
    }

}
