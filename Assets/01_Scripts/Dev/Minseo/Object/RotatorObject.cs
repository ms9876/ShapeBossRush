using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateAngle;
    [SerializeField]
    private SpriteRenderer _gameobject;
    [SerializeField]
    private GameObject die;

    private float rotateSpeed;
    private float currentTime = 0;
    private float changeTime = 3;


    private void Awake()
    {
        _gameobject = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);

        ChangeValue(1, 120, Color.white);
        ChangeValue(-1, 110, Color.blue);
        ChangeValue(1, 135, Color.white);
        ChangeValue(-1, 140, Color.blue);
        ChangeValue(1, 130, Color.white);
        ChangeValue(-1, 135, Color.blue);
    }

    private void ChangeValue(float _angle, float _speed, Color color)
    {
        currentTime += Time.deltaTime;

        if (currentTime >= changeTime)
        {
            rotateAngle.z = _angle;
            rotateSpeed = _speed;

            _gameobject.color = color;
            currentTime = 0;
        }
    }   
}
