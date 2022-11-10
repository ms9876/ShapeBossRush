using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    //목적 : 모든 2D 게임에서 사용가능한 카메라 관리 코드, 대신 다트윈과 씨네마신이 필요한
    //목적2 : 다트윈과 씨네마신 공부

    //프로젝트에서 사용 내용
    //카메라 정보와 어떤 카메라를 사용중인지 관리하는 코드
    //카메라를 움직이는 여러 메서드를 넣을 스크립트



    [SerializeField]
    private CinemachineVirtualCamera _vCam; // 기본 고정 카메라
    [SerializeField]
    private CinemachineVirtualCamera _vRigCam; // 무언가를 따라가는 카메라
    [SerializeField]
    private CinemachineVirtualCamera _vCutSceneCam; // 컷씬용 카메라

    //CinemachineBasicMultiChannelPerlin에 대해서 공부하기 ShakeCam 하는 데 쓸 예정
    private CinemachineBasicMultiChannelPerlin _activePerlin = null; // 공부 예정
    
    private CinemachineVirtualCamera _activeVCam = null; // 현재 사용중인 카메라를 넣어둘 변수

    private int backPriority = 10;
    private int frontPriority = 15;

    public void ChangeRigCam()
    {
        ChangeCam(_vRigCam);
    } // currentCam -> _vRigCam
    public void ChangeVCam()
    {
        ChangeCam(_vCam);
    } // currentCam -> _vCam
    public void ChangeCutSceneCam() // currentCam -> _cutSceneCam
    {
        ChangeCam(_vCutSceneCam);
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
    public void MoveCam(float time, Vector3 moveTransform) //카메라 위치 이동
    {
        Vector3 currentTransform = _activeVCam.transform.position;
        moveTransform.z = currentTransform.z;
        //time 내에 _cam의 위치를 moveTransform위치로 변경
    }
    public void RotationCam()
    {

    }
    public void ShakeCam()
    {

    }
    public void ZoomCam(float value, float time)
    {
        //value값으로 줌 바꾸는 코드
    }
    public void ZoomAndSwitchingCam(float value, float time, float delay)
    {
        //value로 줌을 바꿨다가 원래 값으로 바꾸는 메서드

    }
    public void ChangeRigTarget()
    {
        //RigCam에 타겟을 바꾸는 메서드
    }

}
