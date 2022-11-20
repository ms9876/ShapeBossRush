using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    //컷씬을 관리한다

    CameraManager _vCamManager = null; // 카메라 연출용
    List<CutSceneData> _cutSceneList = new List<CutSceneData>(); // 컷씬별 데이터


    //구현요소
    // 1. 텍스트 출력 요소
    //컷별로 채팅이 특정 위치에 나오도록 한다. / 안 나오게도 가능
    // 2. 컷별 화연 효과
    //컷별로 카메라 연출이 나오도록 한다. / 없이도 가능
    // 3. 컷별 액션
    //예 : 애니메이션 재생, 또는 캐릭터를 움직인다든가

    // Start is called before the first frame update
    void Awake()
    {
        _vCamManager = FindObjectOfType<CameraManager>();
    }

    
}
