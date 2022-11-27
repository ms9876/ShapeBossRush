using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    private Effect[] effects;
    private int stageValue = -1;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private AudioClip[] _audioClip;
    [SerializeField]
    private float _audioVolume = 0.5f;

    

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
    // 0  1  2  3  4  5  6
    // 7  8  9 10 11 12 13
    //14 15 16 17 18 19 20
    //21 22 23 24 25 26 27
    WorldData _worldData = new WorldData(new int[] { 3, 10, 17 }, 3, 2);
    WorldData _worldData2 = new WorldData(new int[] {14, 15, 16, 17}, 14, 1f);
    WorldData _worldData3 = new WorldData(new int[] { 17, 18, 19, 20 }, 20, 1f);

    WorldData _worldData4 = new WorldData(new int[] { 3, 4, 5, 12, 17, 18, 19 }, 3, 2f);
    WorldData _worldData5 = new WorldData(new int[] { 3, 4, 5, 6, 10, 13, 17, 19, 20 }, 19, 2.5f);
    WorldData _worldData6 = new WorldData(new int[] { 0, 1, 2, 3, 4, 5, 7, 12, 17, 19, 24, 25, 26 }, 7, 2.7f);

    WorldData _worldData7 = new WorldData(new int[] { 5, 6, 11, 12, 17, 18 }, 6, 1.3f);
    WorldData _worldData8 = new WorldData(new int[] { 0, 1, 8, 9, 16, 17 }, 0, 1.3f);
    #endregion

    private void Awake()
    {
        _avoidWorld = GetComponent<AvoidWorld>();
        _boxMovingWorld = GetComponent<BoxMovingWorld>();
        _tetrisWorld = GetComponent<TetrisWorld>();
        effects = GetComponentsInChildren<Effect>();
        _audio.volume = _audioVolume;
    }

    private void Start()
    {
        WorldManager.instance.ChangeWorld(_avoidWorld, WorldState.AvoidAndShot);
        Time.timeScale = 1f;
        StartCoroutine("BossPattern");
    }

    IEnumerator BossPattern()
    {
        float shortdelay = 0.1f;
        float delay = 0.15f;
        float shortTerm = 0.3f;
        float term = 0.4f;
        float longTerm = 0.6f;

        text.text = "3";
        yield return new WaitForSeconds(0.5f);
        text.text = "2";
        yield return new WaitForSeconds(0.5f);
        text.text = "1";
        AudioChange(0);
        yield return new WaitForSeconds(0.5f);
        text.gameObject.SetActive(false);
        //
        CameraManager.instance.ResetCam(8, 0);
        _avoidWorld.WorldSetting(_lineListOne);
        _avoidWorld.Player.SetBallPlayer();
        //
        MapEffectSetUp();
        CameraManager.instance.ShakeCam(shortTerm * 9, 3f);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(new int[] { 0, 1, 2, 1, 2, 1, 0, 1, 2 }, shortTerm));
        CameraManager.instance.ZoomCam(shortTerm, 11f);
        MapEffectSetUp();
        CameraManager.instance.WaitValueRotationCam(shortTerm, 30, shortdelay);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 10, 0.1f) + term);
        CameraManager.instance.ZoomCam(shortTerm, 10f);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 0, 2 }, 10, 0.1f) + term);
        CameraManager.instance.ZoomCam(shortTerm, 8f);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 10, 0.1f) + term);
        CameraManager.instance.WaitValueRotationCam(shortTerm, -30, shortdelay);
        CameraManager.instance.ZoomCam(shortTerm, 7f);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(0, 3, 0.1f) + term);
        CameraManager.instance.WaitValueRotationCam(shortTerm, 5, shortdelay);
        CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(1, 3, 0.1f) + term);
        CameraManager.instance.WaitValueRotationCam(shortTerm, -5, shortdelay);
        CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(2, 3, 0.1f) + term);
        CameraManager.instance.WaitValueRotationCam(shortTerm, 5, shortdelay);
        CameraManager.instance.ZoomSwitchingCam(shortTerm, 9f, shortdelay);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 1, 2 }, 10, 0.1f) + longTerm);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(new int[] { 0, 1 }, 10, 0.1f) + longTerm);
        MapEffectSetUp();

        AudioChange(1);
        CameraManager.instance.ZoomSwitchingCam(longTerm, 0.1f, shortdelay);
        CameraManager.instance.ValueRotationCam(longTerm, 360);
        yield return new WaitForSeconds(longTerm+shortdelay);

        
        //
        WorldManager.instance.ChangeWorld(_boxMovingWorld, WorldState.BoxMoving);
        _boxMovingWorld.WorldSetting();
        _boxMovingWorld.Player.SetBoxPlayer();
        CameraManager.instance.ResetCam(8, 0);
        //
       
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData));
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData2));
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData3));
        CameraManager.instance.ValueRotationCam(shortTerm, 360);
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData4));
        CameraManager.instance.WaitValueRotationCam(shortTerm, 30, shortdelay);
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData5));
        CameraManager.instance.WaitValueRotationCam(shortTerm, -30, shortdelay);
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData6));
        CameraManager.instance.DOMoveCam(shortTerm, Vector3.up/2);
        MapEffectSetUp();
        CameraManager.instance.WaitValueRotationCam(shortTerm, 40, shortdelay);
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData7));
        CameraManager.instance.WaitValueRotationCam(shortTerm, -40, shortdelay);
        yield return new WaitForSeconds(_boxMovingWorld.MapSetting(_worldData8));
        CameraManager.instance.DOMoveCam(shortTerm, Vector3.zero);
        yield return new WaitForSeconds(shortTerm);
        
        AudioChange(2);
        //
        WorldManager.instance.ChangeWorld(_avoidWorld, WorldState.AvoidAndShot);
        CameraManager.instance.ResetCam(8, 0);
        _avoidWorld.WorldSetting(_lineListTwo);
        _avoidWorld.Player.SetBallPlayer();
        //
        yield return new WaitForSeconds(shortTerm);
        int[] left = { 0, 1, 2, 3 };
        int[] right = { 4, 3, 2, 1 };
        int[] pattern = { 0, 2, 4 };
        int[] pattern2 = { 1, 3 };
        int[] pattern3 = { 1, 2, 3 };
        int[] pattern4 = { 0, 1, 3, 4 };
        
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(left, delay)+shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(right, delay)+shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(left, delay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(right, delay) + shortTerm);
        CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(left, shortdelay) + shortTerm);
        CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(right, shortdelay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(left, delay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossAttackPattern(right, delay) + shortTerm);

        CameraManager.instance.ValueRotationCam(term, -360);
        MapEffectSetUp();
        yield return new WaitForSeconds(term + shortTerm);
        
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern, 3, shortdelay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern2, 3, shortdelay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern3, 3, shortdelay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern, 3, shortdelay) + shortTerm);
        CameraManager.instance.ShakeCam(shortdelay, 3f);
        CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern3, 3, shortdelay) + term);
        CameraManager.instance.ShakeCam(shortdelay, 3f);
        CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern4, 3, shortdelay) + term);
        CameraManager.instance.ShakeCam(shortdelay, 3f);
        CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern3, 3, shortdelay) + term);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern2, 3, shortdelay) + shortTerm);
        yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(pattern4, 3, shortdelay) + shortTerm);
        
        MapEffectSetUp();
        for (int i=0; i<10; i++)
        {
            int rdIdx = Random.Range(0, 5);
            yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(rdIdx, 3, shortdelay)+shortdelay);
            CameraManager.instance.ZoomSwitchingCam(shortdelay, 8.5f, 0);
        }
        for (int i = 0; i < 20; i++)
        {
            int rdIdx = Random.Range(0, 5);
            yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(rdIdx, 2, shortdelay));
            CameraManager.instance.ZoomSwitchingCam(shortdelay, 8.5f, 0);
        }
        for (int i = 0; i < 20; i++)
        {
            int rdIdx = Random.Range(1, 4);
            yield return new WaitForSeconds(_avoidWorld.BossContinuousAttack(rdIdx, 2, shortdelay)-shortdelay);
            CameraManager.instance.ZoomSwitchingCam(shortdelay, 9f, 0);
        }
        CameraManager.instance.ValueRotationCam(shortTerm, 360f);
        yield return new WaitForSeconds(shortTerm+shortdelay);
        CameraManager.instance.ValueRotationCam(shortTerm, -360f);
        yield return new WaitForSeconds(shortTerm + shortdelay);
        CameraManager.instance.ShakeCam(3f, 100f);
        
        
        yield return new WaitForSeconds(2f);
        AudioChange(3);
        yield return new WaitForSeconds(1f);
        //
        WorldManager.instance.ChangeWorld(_tetrisWorld, WorldState.Tetris);
        CameraManager.instance.ResetCam(8, 0);
        _tetrisWorld.WorldSetting();
        _avoidWorld.Player.SetBallPlayer();
        //
        CameraManager.instance.ZoomCam(shortTerm, 10f);
    }
    
    private void MapEffectSetUp()
    {
        stageValue++;
        foreach(Effect effect in effects)
        {
            if(effect.StageValue <= stageValue)
            {
                effect.gameObject.SetActive(true);
            }
            else
            {
                effect.gameObject.SetActive(false);
            }
        }
    }
    private void AudioChange(int idx)
    {
        
        StartCoroutine(AudioVolumeSet(idx));
    }
    float audioSetTime = 1f;
    IEnumerator AudioVolumeSet(int idx)
    {
        float currentTime = 0;
        while (audioSetTime/2 > currentTime)
        {
            yield return new WaitForEndOfFrame();
            _audio.volume = Mathf.Lerp(_audioVolume, 0, currentTime / audioSetTime);
            currentTime += Time.deltaTime;
        }
        _audio.volume = 0;
        _audio.clip = _audioClip[idx];
        _audio.Play();
        currentTime = 0;
        while(audioSetTime/2 > currentTime)
        {
            yield return new WaitForEndOfFrame();
            _audio.volume = Mathf.Lerp(0, _audioVolume, currentTime / audioSetTime);
            currentTime += Time.deltaTime;
        }
        _audio.volume = _audioVolume;
    }
    
}
