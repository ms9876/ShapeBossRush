using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] GameObject _vCamObj = null;

    CinemachineVirtualCamera _vCam = null;
    Transform _vCamTransform = null;
    // Sequence seq = DOTween.Sequence();

    private void Awake()
    {
        _vCamTransform = _vCamObj.GetComponent<Transform>();
        _vCam = _vCamObj.GetComponent<CinemachineVirtualCamera>();
    }

    void Start()
    {
        DoShakeCam();
    }

    void Update()
    {
        
    }

    public void DoShakeCam()
    {
        StopAllCoroutines();
        StartCoroutine(Shake(0.1f, 1f));
        
    }

    // 카메라 매우 빠르게 흔들기
    public IEnumerator Shake(float _amount, float _duration)
    {
        Vector3 originPos = _vCamTransform.position;
        float timer = 0;
        while (timer <= _duration)
        {
            _vCamTransform.position = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        _vCamTransform.position = originPos;
    }
    // 카메라 통통 튀듯이 흔들기
    // 카메라 회전시키기 오른쪽 왼쪽
    // 카메라 줄였다가 원래되로 되돌리기
    // 카메라 움직이면서 크기 바꾸기
    // 카메라 페이드인 페이드아웃
}
