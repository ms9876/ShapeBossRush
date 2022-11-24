using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
using System;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    //목적 : 모든 2D 게임에서 사용가능한 카메라 관리 코드, 대신 다트윈과 씨네마신이 필요한
    //목적2 : 다트윈과 씨네마신 공부

    //프로젝트에서 사용 내용
    //카메라 정보와 어떤 카메라를 사용중인지 관리하는 코드
    //카메라를 움직이는 여러 메서드를 넣을 스크립트

    private CinemachineVirtualCamera _vCam; // 기본 고정 카메라
    private CinemachineVirtualCamera _vRigCam; // 무언가를 따라가는 카메라
    private CinemachineVirtualCamera _vCutSceneCam; // 컷씬용 카메라

    private CinemachineBasicMultiChannelPerlin _vCamPerlin;
    private CinemachineBasicMultiChannelPerlin _vRigCamPerlin;
    private CinemachineBasicMultiChannelPerlin _vCutSceneCamPerlin;
    //CinemachineBasicMultiChannelPerlin에 대해서 공부하기, ShakeCam 하는 데 쓸 예정

    private CinemachineBasicMultiChannelPerlin _activePerlin = null; // 공부 예정
    private CinemachineVirtualCamera _activeVCam = null; // 현재 사용중인 카메라를 넣어둘 변수

    private int backPriority = 10;
    private int frontPriority = 15;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple CamaraManager instance is running");
        }
        instance = this;

        Init();
        ChangeVCam();
    }
    public void Init()
    {
        _vRigCam = GameObject.Find("vRigCam").GetComponent<CinemachineVirtualCamera>();
        _vCam = GameObject.Find("vCam").GetComponent<CinemachineVirtualCamera>();
        _vCutSceneCam = GameObject.Find("vCutSceneCam").GetComponent<CinemachineVirtualCamera>();

        if (_vCam != null)
            _vCamPerlin = _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (_vRigCam != null)
            _vRigCamPerlin = _vRigCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (_vCutSceneCam != null)
            _vCutSceneCamPerlin = _vCutSceneCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    public void ChangeRigCam()
    {
        ChangeCam(_vRigCam);
        if(_vRigCamPerlin != null)
            _activePerlin = _vRigCamPerlin;
    } // currentCam -> _vRigCam
    public void ChangeVCam()
    {
        ChangeCam(_vCam);
        if(_vCamPerlin != null)
            _activePerlin = _vCamPerlin;
    } // currentCam -> _vCam
    public void ChangeCutSceneCam() // currentCam -> _cutSceneCam
    {
        ChangeCam(_vCutSceneCam);
        if(_vCutSceneCamPerlin != null)
            _activePerlin = _vCutSceneCamPerlin;
    }
    private void ChangeCam(CinemachineVirtualCamera _cam) // currentCam -> _cam
    {
        _vCam.Priority = backPriority;
        _vRigCam.Priority = backPriority;
        _vCutSceneCam.Priority = backPriority;

        _cam.Priority = frontPriority;
        _activeVCam = _cam;
    }

    // 구현 목록
    public void ResetCam(float zoomValue, float rotationValue)
    {
        _activeVCam.transform.position = new Vector3(0, 0, _activeVCam.transform.position.z);
        _activeVCam.m_Lens.OrthographicSize = zoomValue;
        _activeVCam.transform.rotation = Quaternion.Euler(0, 0, rotationValue);
    }

    public void DOMoveCam(float time, Vector3 moveTransform) //카메라 위치 이동
    {
        if (_activeVCam == null) return;
        Vector3 currentTransform = _activeVCam.transform.position;
        moveTransform.z = currentTransform.z;

        _activeVCam.transform.DOMove(moveTransform, time);
        //time 내에 _cam의 위치를 moveTransform위치로 변경
    }
    public void RotationCam(float time, float rotationValue) // 특정 값"만큼" 돌리기
    {
        if (_activeVCam == null) return;
        StartCoroutine(RotationCamcoroutine(time, rotationValue));
    }
    IEnumerator RotationCamcoroutine(float time, float rotationValue)
    {
        float currentTime = 0f;
        float originRotate = _activeVCam.transform.eulerAngles.z;
        originRotate = originRotate >= 180 ? originRotate - 360f : originRotate;
        while (currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            _activeVCam.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(originRotate, originRotate + rotationValue, currentTime / time));
            currentTime += Time.deltaTime;
        }
        _activeVCam.transform.rotation = Quaternion.Euler(0, 0, originRotate + rotationValue);
    }

    public void ValueRotationCam(float time, float rotationValue)
    {
        if (_activeVCam == null) return;
        StartCoroutine(ValueRotationCamcoroutine(time, rotationValue));
        //현재 -에서 +로 가면 한 바퀴 회전하는 버그 발생
    } // 특정 값"으로" 돌리기
    IEnumerator ValueRotationCamcoroutine(float time, float rotationValue) //나중에 돌아가는 방향 관련 코드 만들기
    {
        float currentTime = 0f;
        float originRotate = _activeVCam.transform.eulerAngles.z;
        originRotate = originRotate >= 180 ? originRotate - 360f : originRotate;
        while (currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            _activeVCam.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(originRotate, rotationValue, currentTime / time));
            currentTime += Time.deltaTime;
        }
        _activeVCam.transform.rotation = Quaternion.Euler(0, 0, rotationValue);
    }
    public void WaitValueRotationCam(float time, float rotationValue, float delay) // 특정 값으로 돌렸다가 정위치로
    {
        if (_activeVCam == null) return;
        StartCoroutine(WaitValueRotationCamcoroutine(time, rotationValue, delay));
    }
    IEnumerator WaitValueRotationCamcoroutine(float time, float rotationValue, float delay)
    {
        float halfTime = time / 2;
        float originRotate = _activeVCam.transform.eulerAngles.z;
        ValueRotationCam(halfTime, rotationValue);
        yield return new WaitForSeconds(delay+halfTime);
        ValueRotationCam(halfTime, originRotate);
    }

    public void ShakeCam(float time, float shakeValue)
    {
        //_activePerlin사용
        if (_activeVCam == null || _activePerlin == null) return;
        StartCoroutine(ShakeCamcoroutine(time, shakeValue));
    }
    IEnumerator ShakeCamcoroutine(float time, float shakeValue)
    {
        _activePerlin.m_AmplitudeGain = shakeValue;
        float currentTime = 0f;
        while(currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            if (_activePerlin == null) break;
            _activePerlin.m_AmplitudeGain = Mathf.Lerp(shakeValue, 0, currentTime/time);
            currentTime += Time.deltaTime;
        }
        _activePerlin.m_AmplitudeGain = 0;
    }
    public void ZoomCam(float time, float value)
    {
        if (_activeVCam == null) return;
        //value값으로 줌 바꾸는 코드
        StartCoroutine(ZoomCamcoroutine(time, value));
    }
    IEnumerator ZoomCamcoroutine(float time, float value)
    {
        float currentTime = 0f;
        float originOrthographicSize = _activeVCam.m_Lens.OrthographicSize;
        while (currentTime < time)
        {
            yield return new WaitForEndOfFrame();
            _activeVCam.m_Lens.OrthographicSize = Mathf.Lerp(originOrthographicSize, value, currentTime / time);
            currentTime += Time.deltaTime;
        }
        _activeVCam.m_Lens.OrthographicSize = value;
    }
    public void ZoomSwitchingCam(float time, float value, float delay)
    {
        if (_activeVCam == null) return;
        //value로 줌을 바꿨다가 원래 값으로 바꾸는 메서드
        StartCoroutine(ZoomSwitchingCamcoroutine(time, value, delay));
    }
    IEnumerator ZoomSwitchingCamcoroutine(float time, float value, float delay)
    {
        float originOrthographicSize = _activeVCam.m_Lens.OrthographicSize;
        float halfTime = time / 2;
        StartCoroutine(ZoomCamcoroutine(halfTime, value));
        yield return new WaitForSeconds(halfTime + delay);
        StartCoroutine(ZoomCamcoroutine(halfTime, originOrthographicSize));
    }
    public void SetConfiner(PolygonCollider2D confiner)
    {
        _vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
        _vRigCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
        _vCutSceneCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = confiner;
    }
    //RIg전용
    public void ChangeRigTarget(Transform target)
    {
        if (_activeVCam == null) return;
        //RigCam에 타겟을 바꾸는 메서드
        _vRigCam.Follow = target;

    }


    

}
