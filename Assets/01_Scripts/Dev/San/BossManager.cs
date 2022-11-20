using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private AvoidWorld _avoidWorld;
    private BoxMovingWorld _boxMovingWorld;
    private TetrisWorld _tetrisWorld;

    private WorldManager _worldManager;

    [SerializeField]
    private Vector2[] _lineListOne;
    [SerializeField]
    private Vector2[] _lineListTwo;
    [SerializeField]
    private Vector2[] _lineListThree;
    [SerializeField]
    private Vector2[] _lineListFour;

    private void Awake()
    {
        _avoidWorld = GetComponent<AvoidWorld>();
        _boxMovingWorld = GetComponent<BoxMovingWorld>();
        _tetrisWorld = GetComponent<TetrisWorld>();
        _worldManager = GetComponent<WorldManager>();
    }

    private void Start()
    {
        _worldManager.ChangeWorld(_avoidWorld, WorldState.AvoidAndShot);
        StartCoroutine("BossPattern");
    }

    IEnumerator BossPattern()
    {
        
        _avoidWorld.WorldSetting(_lineListOne);
        yield return null;
    }
}
