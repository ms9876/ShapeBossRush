using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rigidbody = null;

    // 플레이어 이동키
    [SerializeField] KeyCode _leftKey = KeyCode.None;
    [SerializeField] KeyCode _rightKey = KeyCode.None;
    [SerializeField] KeyCode _upKey = KeyCode.None;
    [SerializeField] KeyCode _downKey = KeyCode.None;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
