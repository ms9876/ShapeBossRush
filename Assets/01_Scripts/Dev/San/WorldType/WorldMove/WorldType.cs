using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldType : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _playerRigidbody;
    private Player _player;
    private int _damageAbleLayer;

    public Transform PlayerTransform => _playerTransform;
    public Rigidbody2D PlayerRigidbody => _playerRigidbody;
    public Player Player => _player;
    public int DamageAbleLayer => _damageAbleLayer;

    private KeyCode _upKey = KeyCode.W;
    private KeyCode _leftKey = KeyCode.A;
    private KeyCode _downKey = KeyCode.S;
    private KeyCode _rightKey = KeyCode.D;

    public KeyCode UpKey => _upKey;
    public KeyCode LeftKey => _leftKey;
    public KeyCode DownKey => _downKey;
    public KeyCode RightKey => _rightKey;

    private void Awake()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _playerRigidbody = _playerTransform.GetComponent<Rigidbody2D>();
        _player = _playerTransform.GetComponent<Player>();
        _damageAbleLayer = LayerMask.GetMask("DamageAbleMono");
    }
}
