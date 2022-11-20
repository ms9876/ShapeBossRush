using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CutSceneData : MonoBehaviour
{
    //컷씬에 각부분을 나눈다
    //컷씬매니저 > 컷씬 > 컷씬데이터
    //컷씬매니저 안에 모든 컷씬을 정리한다.
    //컷씬 안에 모든 컷씬데이터를 정리한다.
    public float Delay = 0;


    public abstract void CutAction(); //추상메서드
    
}
