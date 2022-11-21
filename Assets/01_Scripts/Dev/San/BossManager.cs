using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    private AvoidWorld _avoidWorld;
    private BoxMovingWorld _boxMovingWorld;
    private TetrisWorld _tetrisWorld;

    #region avoidWorld
    [SerializeField]
    private Vector2[] _lineListOne;
    [SerializeField]
    private Vector2[] _lineListTwo;
    [SerializeField]
    private Vector2[] _lineListThree;
    [SerializeField]
    private Vector2[] _lineListFour;
    #endregion
    #region boxMoving
    int[] halfLeft = { 0, 1, 2, 3, 7, 8, 9, 10, 14, 15, 16, 17, 21, 22, 23, 24 };
    int[] halfRight = { 3, 4, 5, 6, 10, 11, 12, 13, 17, 18, 19, 20, 24, 25, 26, 27 };
    #endregion

    private void Awake()
    {
        _avoidWorld = GetComponent<AvoidWorld>();
        _boxMovingWorld = GetComponent<BoxMovingWorld>();
        _tetrisWorld = GetComponent<TetrisWorld>();
    }

    private void Start()
    {
        WorldManager.instance.ChangeWorld(_avoidWorld, WorldState.AvoidAndShot);
        StartCoroutine("BossPattern");
    }

    IEnumerator BossPattern()
    {
        float shortdelay = 0.1f;
        float shortTerm = 0.3f;
        float term = 0.4f;
        float longTerm = 0.6f;
        //CameraManager.instance.ResetCam(8, 0);
        //_avoidWorld.WorldSetting(_lineListOne);
        //_avoidWorld.Player.SetBallPlayer();
        //CameraManager.instance.ShakeCam(shortTerm*9, 3f);
        //yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(new int[] { 0, 1, 2, 1, 2, 1, 0, 1, 2 }, shortTerm));
        //CameraManager.instance.ZoomCam(shortTerm, 11f);
        //CameraManager.instance.WaitValueRotationCam(shortTerm, 30, shortdelay);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 10, 0.1f) + term);
        //CameraManager.instance.ZoomCam(shortTerm, 10f);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 0, 2 }, 10, 0.1f) + term);
        //CameraManager.instance.ZoomCam(shortTerm, 8f);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 10, 0.1f) + term);
        //CameraManager.instance.WaitValueRotationCam(shortTerm, -30, shortdelay);
        //CameraManager.instance.ZoomCam(shortTerm, 7f);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(0, 3, 0.1f) + term);
        //CameraManager.instance.WaitValueRotationCam(shortTerm, 5, shortdelay);
        //CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 3, 0.1f) + term);
        //CameraManager.instance.WaitValueRotationCam(shortTerm, -5, shortdelay);
        //CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(2, 3, 0.1f) + term);
        //CameraManager.instance.WaitValueRotationCam(shortTerm, 5, shortdelay);
        //CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 1, 2 }, 10, 0.1f) + longTerm);
        //yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 0, 1 }, 10, 0.1f) + longTerm);

        //CameraManager.instance.ZoomSwitchingCam(1f, 0.1f, shortdelay);
        //CameraManager.instance.ValueRotationCam(1.1f, 360);
        yield return new WaitForSeconds(term);
        WorldManager.instance.ChangeWorld(_boxMovingWorld, WorldState.BoxMoving);
        _boxMovingWorld.WorldSetting();
        _boxMovingWorld.Player.SetBoxPlayer();
        CameraManager.instance.ZoomCam(shortTerm, 8f);
        yield return new WaitForSeconds(longTerm);
        



    }
}
